namespace Membership.Service
{
    using System;
    using System.Collections.Concurrent;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using Membership.Contract;
    using Membership.Data;
    using Membership.Data.Entity;
    using System.Collections.Generic;

    /// <summary>
    /// The user membership service.
    /// </summary>
    public class UserMembershipService : BaseMembershipService, IUserMembershipService
    {
        private ConcurrentDictionary<string, string> UserLoginDictionary { get; set; }
        private ConcurrentDictionary<string, UserDto> UserDictionary { get; set; }
        private ConcurrentDictionary<int, UserDto> UserByIdDictionary { get; set; }

        public UserMembershipService()
        {
            this.UserDictionary = new ConcurrentDictionary<string, UserDto>();
            this.UserLoginDictionary = new ConcurrentDictionary<string, string>();
            this.UserByIdDictionary = new ConcurrentDictionary<int, UserDto>();

            var userLogin = this.db.Users.Where(x => x.DeletedOn.HasValue == false).Select(user => new { user.Email, user.PasswordHash });
            foreach (var user in userLogin)
            {
                this.UserLoginDictionary.TryAdd(user.Email, user.PasswordHash);
            }

            var users = this.db.Users.Include(x => x.UserType).Include(x => x.Gender).Where(x => x.DeletedOn.HasValue == false).OrderBy(x => x.Id);
            foreach (var user in users)
            {
                var dto = Mapper.Map<User, UserDto>(user);
                UserDictionary.TryAdd(user.Email, dto);
                UserByIdDictionary.TryAdd(user.Id, dto);
            }
        }

        /// <summary>
        /// The auth user.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="passwordHash">
        /// The password hash.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public bool AuthUser(string userName, string passwordHash)
        {
            var auth = false;
            if (this.DoesUserEmailExists(userName))
            {
                auth = this.UserLoginDictionary[userName] == passwordHash;
            }

            return auth;
        }

        /// <summary>
        /// The create user.
        /// </summary>
        /// <param name="dto">
        /// The userDto.
        /// </param>
        /// <returns>
        /// The System.Int32 userId.
        /// </returns>
        public int CreateUser(UserDto dto)
        {
            if (!this.DoesUserEmailExists(dto.Email))
            {
                this.db.Users.Add(new User
                                 {
                                     CreatedOn = DateTime.Now,
                                     UpdatedOn = DateTime.Now,
                                     UpdatedBy = 1,
                                     Comment = dto.Comment,
                                     IsActive = true,
                                     IsMailingActive = true,
                                     IsOtherMailingActive = true,
                                     Names = dto.Names,
                                     FirstName = dto.FirstName,
                                     LastName = dto.LastName,
                                     PreferredName = dto.PreferredName,
                                     Email = dto.Email,
                                     PasswordHash = dto.PasswordHash,
                                     RefererSource = dto.RefererSource,
                                     GenderId = dto.Gender.Id,
                                     UserTypeId = dto.UserType.Id,
                                     Point = 0,
                                     VirtualMoney = 0,
                                     Birthday = dto.Birthday,
                                     PhotoUrl = dto.PhotoUrl,
                                     TwitterId = dto.TwitterId,
                                     FacebookId = dto.FacebookId,
                                     Website = dto.Website,
                                     IdentityNumber = dto.IdentityNumber,
                                     AffiliateSlug = dto.AffiliateSlug

                                 });
                this.db.SaveChanges();

                var user = this.db.Users.FirstOrDefault(x => x.Email == dto.Email);
                if (user != null)
                {
                    this.UserLoginDictionary.TryAdd(user.Email, user.PasswordHash);

                    var userDto = Mapper.Map<User, UserDto>(user);
                    this.UserDictionary.TryAdd(user.Email, userDto);

                    return user.Id;
                }
            }

            return 0;
        }

        /// <summary>
        /// The does user email exists.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The System.Boolean result.
        /// </returns>
        public bool DoesUserEmailExists(string email)
        {
            return this.UserLoginDictionary.ContainsKey(email);
        }

        /// <summary>
        /// The delete user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public bool DeleteUser(string email)
        {
            if (this.DoesUserEmailExists(email))
            {
                var user = this.db.Users.FirstOrDefault(x => x.Email == email);
                if (user != null)
                {
                    user.DeletedOn = DateTime.Now;
                    user.UpdatedBy = user.Id;

                    this.db.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The request password reset for user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public bool RequestPasswordReset(string email)
        {
            if (this.DoesUserEmailExists(email))
            {
                var guid = Guid.NewGuid().ToString().Replace("-", string.Empty);

                var user = this.db.Users.First(x => x.Email == email);
                user.UpdatedOn = DateTime.Now;
                user.UpdatedBy = user.Id;
                user.PasswordResetToken = guid;
                user.PasswordResetRequestedOn = DateTime.Now;

                this.db.SaveChanges();

                //todo: send password reset mail

                return true;
            }

            return false;
        }

        public bool IsPasswordResetRequestValid(string email, string guid)
        {
            if (this.DoesUserEmailExists(email))
            {
                var user = this.db.Users.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email == email);
                if (user != null)
                {
                    if (guid != null && user.PasswordResetToken == guid.Trim())
                    {
                        if (user.PasswordResetRequestedOn.HasValue)
                        {
                            if (user.PasswordResetRequestedOn.Value.AddDays(1) > DateTime.Now)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// The change password for user.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="newPasswordHash">
        /// The new password hash.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public bool ChangePassword(string email, string newPasswordHash)
        {
            if (this.DoesUserEmailExists(email))
            {
                var user = this.db.Users.First(x => x.Email == email);
                if (user != null)
                {
                    user.PasswordHash = newPasswordHash;
                    user.UpdatedBy = user.Id;
                    user.UpdatedOn = DateTime.Now;

                    this.db.SaveChanges();

                    var dto = Mapper.Map<User, UserDto>(user);
                    this.UserDictionary[email] = dto;
                    this.UserLoginDictionary[email] = newPasswordHash;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The add address.
        /// </summary>
        /// <param name="dto">
        /// The dto.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public int AddAddress(AddressDto dto)
        {
            if (!this.db.Addresses.Any(x => x.DeletedOn.HasValue == false && x.UserId == dto.User.Id && x.Name.Trim() == dto.Name.Trim()))
            {
                this.db.Addresses.Add(new Address
                    {
                        Name = dto.Name.Trim(),
                        AddressText = dto.AddressText.Trim(),
                        AddressType = dto.AddressType.Trim(),
                        //District = dto.District.Trim(),
                        CountyId = dto.County.Id,
                        CityId = dto.City.Id,
                        PostalCode = dto.PostalCode.Trim(),
                        PersonName = dto.PersonName.Trim(),
                        PrimaryPhone = dto.PrimaryPhone.Trim(),
                        CompanyName = dto.CompanyName.Trim(),
                        TaxNumber = dto.TaxNumber.Trim(),
                        TaxOffice = dto.TaxOffice.Trim(),
                        IsApproved = dto.IsApproved,
                        IsCompany = dto.IsCompany,
                        UserId = dto.User.Id,
                        UpdatedOn = DateTime.Now,
                        CreatedOn = DateTime.Now,
                        UpdatedBy = dto.UpdatedBy,
                        Comment = dto.Comment
                    });
                this.db.SaveChanges();

                var topAddress = this.db.Addresses.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Name == dto.Name.Trim() && x.UserId == dto.User.Id);
                return topAddress.Id;
            }

            return 0;
        }

        public bool AddPhone(PhoneDto dto)
        {
            if (!this.db.Phones.Any(x => x.DeletedOn.HasValue == false && x.UserId == dto.User.Id && x.Telephone.Trim() == dto.Telephone.Trim()))
            {
                this.db.Phones.Add(new Phone
                {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = dto.User.Id,
                    IsFax = dto.IsFax,
                    IsPrimary = dto.IsPrimary,
                    Comment = dto.Comment,
                    Telephone = dto.Telephone.Trim(),
                    UserId = dto.User.Id
                });

                this.db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool InviteUser(string refererUserEmail, string invitedEmail)
        {
            if (this.DoesUserEmailExists(refererUserEmail))
            {
                if (!this.db.Affiliates.Any(x => x.DeletedOn.HasValue == false && x.Email == invitedEmail))
                {
                    this.db.Affiliates.Add(new Affiliate
                        {
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now,
                            UpdatedBy = this.GetUserIdByEmail(refererUserEmail),
                            Email = invitedEmail
                        });

                    this.db.SaveChanges();

                    //todo: send invite email

                    return true;
                }
            }

            return false;
        }

        public bool InviteSucceeded(string refererUserEmail, string invitedEmail)
        {
            if (this.DoesUserEmailExists(refererUserEmail))
            {
                var affliate = this.db.Affiliates.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email == invitedEmail && x.RefererSource == refererUserEmail);
                if (affliate != null)
                {
                    affliate.UpdatedOn = DateTime.Now;
                    affliate.ActivatedOn = DateTime.Now;

                    this.db.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public UserDto GetUserById(int id)
        {
            UserDto user = null;
            if (this.UserByIdDictionary.ContainsKey(id))
            {
                user = this.UserByIdDictionary[id];
            }

            return user;
        }

        /// <summary>
        /// The get user. Give the users email and get the dto.
        /// </summary>
        /// <param name="email">
        /// The user's email.
        /// </param>
        /// <returns>
        /// The Membership.Contract.UserDto.
        /// </returns>
        public UserDto GetUser(string email)
        {
            UserDto user = null;
            if (this.DoesUserEmailExists(email))
            {
                user = this.UserDictionary[email];
            }

            return user;
        }

        public int GetUserIdByEmail(string email)
        {

            if (this.DoesUserEmailExists(email))
            {
                return this.UserDictionary[email].Id;

            }
            return 0;
        }

        public string GetUserEmailById(int id)
        {
            if (this.UserByIdDictionary.ContainsKey(id))
            {
                return this.UserByIdDictionary[id].Email;
            }
            return null;
        }

        public bool UpdateAddress(AddressDto dto)
        {
            var address = this.db.Addresses.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.UserId == dto.User.Id && x.Id == dto.Id);

            if (address != null)
            {
                address.Name = dto.Name.Trim();
                address.AddressText = dto.AddressText.Trim();
                address.AddressType = dto.AddressType.Trim();
                address.CountyId = dto.County.Id;
                address.CityId = dto.City.Id;
                address.PostalCode = dto.PostalCode.Trim();
                address.PersonName = dto.PersonName.Trim();
                address.PrimaryPhone = dto.PrimaryPhone.Trim();
                address.CompanyName = dto.CompanyName.Trim();
                address.TaxNumber = dto.TaxNumber.Trim();
                address.TaxOffice = dto.TaxOffice.Trim();
                address.IsApproved = dto.IsApproved;
                address.IsCompany = dto.IsCompany;
                address.UpdatedOn = DateTime.Now;
                address.UpdatedBy = dto.UpdatedBy;
                address.Comment = dto.Comment;

                this.db.SaveChanges();

                return true;
            }

            return false;

        }

        public bool UpdatePhone(PhoneDto dto)
        {
            var phone = this.db.Phones.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.UserId == dto.User.Id && x.Telephone.Trim() == dto.Telephone.Trim());

            if (phone != null)
            {
                phone.Telephone = dto.Telephone;
                phone.IsFax = dto.IsFax;
                phone.IsPrimary = dto.IsPrimary;
                phone.UpdatedBy = dto.UpdatedBy;
                phone.Comment = dto.Comment;
                phone.UpdatedOn = DateTime.Now;
                phone.UpdatedBy = dto.UpdatedBy;

                this.db.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DeleteAddress(AddressDto dto)
        {
            var address = this.db.Addresses.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (address != null)
            {
                address.DeletedOn = DateTime.Now;
                address.UpdatedBy = dto.UpdatedBy;

                this.db.SaveChanges();

                return true;
            }

            return false;

        }

        public bool DeletePhone(PhoneDto dto)
        {
            var phone = this.db.Phones.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.UserId == dto.User.Id && x.Telephone.Trim() == dto.Telephone.Trim());
            if (phone != null)
            {
                phone.DeletedOn = DateTime.Now;
                phone.UpdatedBy = dto.UpdatedBy;
                this.db.SaveChanges();
            }

            return false;

        }

        public List<PhoneDto> GetPhones(string email)
        {
            var id = GetUserIdByEmail(email);

            var phones = this.db.Phones.Include(x => x.User).Where(x => x.DeletedOn.HasValue == false && x.UserId == id);

            var dtos = new List<PhoneDto>();
            foreach (var phone in phones)
            {
                dtos.Add(Mapper.Map<Phone, PhoneDto>(phone));
            }

            return dtos;
        }

        public List<PhoneDto> GetPhonesByUserId(int id)
        {
            var phones = this.db.Phones.Include(x => x.User).Where(x => x.DeletedOn.HasValue == false && x.UserId == id);

            var dtos = new List<PhoneDto>();
            foreach (var phone in phones)
            {
                dtos.Add(Mapper.Map<Phone, PhoneDto>(phone));
            }

            return dtos;
        }

        public List<AddressDto> GetAddresses(string email)
        {
            int userId = GetUserIdByEmail(email);
            var addresses = this.db.Addresses
                        .Include(x => x.User)
                        .Include(x => x.County)
                        .Include(x => x.City)
                        .Where(x => x.DeletedOn.HasValue == false && x.UserId == userId);

            var dtos = new List<AddressDto>();
            foreach (var address in addresses)
            {
                dtos.Add(Mapper.Map<Address, AddressDto>(address));
            }

            return dtos;
        }

        public List<AddressDto> GetAddressesByUserId(int id)
        {
            var addresses = this.db.Addresses.Include(x => x.User)
                        .Include(x => x.County)
                        .Include(x => x.City)
                        .Where(x => x.DeletedOn.HasValue == false && x.User.Id == id);

            var dtos = new List<AddressDto>();

            foreach (var address in addresses)
            {
                dtos.Add(Mapper.Map<Address, AddressDto>(address));
            }

            return dtos;
        }

        public AddressDto GetAddressById(int id)
        {
            var address = this.db.Addresses.Include(x => x.User)
                        .Include(x => x.County)
                        .Include(x => x.City)
                        .FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == id);

            if (address != null)
            {
                return Mapper.Map<Address, AddressDto>(address);
            }

            return null;

        }

        public bool UpdateUser(UserDto dto)
        {
            var user = this.db.Users.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id);
            if (user != null)
            {
                user.AffiliateSlug = dto.AffiliateSlug;
                user.Birthday = dto.Birthday;
                user.Email = dto.Email;
                user.FacebookId = dto.FacebookId;
                user.FirstName = dto.FirstName;
                user.GenderId = dto.Gender.Id;
                user.IdentityNumber = dto.IdentityNumber;
                user.IsActive = dto.IsActive;
                user.IsMailingActive = dto.IsMailingActive;
                user.IsOtherMailingActive = dto.IsOtherMailingActive;
                user.LastInvoiceAddressId = dto.LastInvoiceAddressId;
                user.LastName = dto.LastName;
                user.LastShippingAddressId = dto.LastShippingAddressId;
                user.Names = dto.Names;
                user.PasswordHash = dto.PasswordHash;
                user.PhotoUrl = dto.PhotoUrl;
                user.PinterestId = dto.PinterestId;
                user.Point = dto.Point;
                user.PreferredName = dto.PreferredName;
                user.RefererSource = dto.RefererSource;
                user.Website = dto.Website;
                user.TwitterId = dto.TwitterId;
                user.VirtualMoney = dto.VirtualMoney;
                user.UserTypeId = dto.UserType.Id;
                user.SkypeId = dto.SkypeId;

                user.Comment = dto.Comment;
                user.UpdatedOn = DateTime.Now;
                user.UpdatedBy = dto.UpdatedBy;

                this.db.SaveChanges();

                this.UserLoginDictionary.AddOrUpdate(user.Email, user.PasswordHash, (k, v) => user.PasswordHash);

                var userDto = Mapper.Map<User, UserDto>(user);
                this.UserDictionary.AddOrUpdate(user.Email, userDto, (k, v) => userDto);

                return true;
            }

            return false;
        }

        public bool UpdateUserBirthday(string email, DateTime birthday)
        {
            var user = this.db.Users.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email.Trim() == email.Trim());
            if (user != null)
            {
                user.Birthday = birthday;
                this.db.SaveChanges();

                return true;
            }
            return false;
        }

        public bool UpdateUserEmail(string oldEmail, string newEmail)
        {
            var user = this.db.Users.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email.Trim() == oldEmail.Trim());
            if (user != null)
            {
                user.Email = newEmail;
                this.db.SaveChanges();

                return true;
            }
            return false;
        }

        public bool UpdateUserNames(string email, string newNames)
        {
            var user = this.db.Users.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email.Trim() == email.Trim());
            if (user != null)
            {
                user.Names = newNames;
                this.db.SaveChanges();

                return true;
            }
            return false;
        }

        public bool UpdateUserPassword(string email, string newPassword)
        {
            var user = this.db.Users.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email.Trim() == email.Trim());
            if (user != null)
            {
                user.PasswordHash = newPassword;
                this.db.SaveChanges();

                return true;
            }
            return false;
        }

        public bool UpdateUserPhone(string email, string oldPhone, string newPhone)
        {
            int userId = this.GetUserIdByEmail(email);
            var phone = this.db.Phones.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.UserId == userId && x.Telephone.Trim() == oldPhone.Trim());
            if (phone != null)
            {
                phone.Telephone = newPhone.Trim();
                this.db.SaveChanges();

                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets from db.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<UserDto> GetTopXByPoint(int count)
        {
            var users = this.db.Users
                .Where(x => x.DeletedOn.HasValue == false).OrderBy(x => x.Point).Take(count);

            var dtos = new List<UserDto>();

            if (users != null)
            {
                foreach (var user in users)
                {
                    dtos.Add(Mapper.Map<User, UserDto>(user));
                }
                return dtos;
            }

            return null;
        }

        /// <summary>
        /// Gets from Dictionary Cache.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public PointTableDto GetTopXByPointWithUser(int count, string email)
        {
            var result = new PointTableDto();
            var users = this.UserDictionary.OrderBy(x => x.Value.Point).Take(count).ToList();
            if (users != null)
            {
                result.TopList = new List<UserDto>();

                var usersOrder = 0;
                foreach (var user in users)
                {
                    result.TopList.Add(user.Value);
                    if (user.Value.Email == email.Trim())
                    {
                        usersOrder++;
                        result.IsUserInTop = true;
                        result.AskingUser = user.Value;
                        result.AskingUsersOrder = usersOrder;
                    }
                }

                if (!result.IsUserInTop)
                {
                    usersOrder = 0;
                    var allUsers = this.UserDictionary.OrderBy(x => x.Value.Point);

                    foreach (var item in allUsers)
                    {
                        usersOrder++;
                        if (item.Value.Email == email.Trim())
                        {
                            usersOrder++;
                            result.IsUserInTop = true;
                            result.AskingUser = item.Value;
                            result.AskingUsersOrder = usersOrder;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public bool UpdateUserPoint(PointHistoryDto dto)
        {
            var user = this.db.Users.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.User.Id);
            if (user != null)
            {
                this.db.PointHistories.Add(new PointHistory
                {
                    CreatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment,

                    Point = dto.Point,
                    PointTypeId = dto.PointType.Id,
                    Expression = dto.Expression

                });

                user.Point += dto.Point;

                UserByIdDictionary[dto.User.Id].Point = user.Point;
                UserDictionary[user.Email].Point = user.Point;

                this.db.SaveChanges();

                return true;
            }
            return false;
        }

        public UserDto GetUserByFacebookId(string fid)
        {
            var userData = this.UserDictionary.Values.FirstOrDefault(x => x.FacebookId == fid.Trim());
            if (userData != null)
            {
                return userData;
            }
            return null;
        }
    }
}
