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
    public class UserMembershipService : IUserMembershipService
    {
        private ConcurrentDictionary<string, string> UserLoginDictionary { get; set; }
        private ConcurrentDictionary<string, UserDto> UserDictionary { get; set; }
        private ConcurrentDictionary<int, UserDto> UserByIdDictionary { get; set; }

        private MembershipDB db = new MembershipDB();

        public UserMembershipService()
        {
            AutoMapperConfiguration.CreateMaps();

            this.UserDictionary = new ConcurrentDictionary<string, UserDto>();
            this.UserLoginDictionary = new ConcurrentDictionary<string, string>();
            this.UserByIdDictionary = new ConcurrentDictionary<int, UserDto>();

            int userCount = this.db.Users.Count(x => x.DeletedOn.HasValue == false);
            int firstTake = userCount / 2;
            int secondTake = userCount - firstTake;

            var userLoginTask = new Task(() =>
            {
                var userLogin = this.db.Users.Where(x => x.DeletedOn.HasValue == false).Select(user => new { user.Email, user.PasswordHash });
                foreach (var user in userLogin)
                {
                    this.UserLoginDictionary.TryAdd(user.Email, user.PasswordHash);
                }
            });
            userLoginTask.Start();

            var usersTask1 = new Task(() =>
            {
                var users = this.db.Users.Include(x => x.UserType).Include(x => x.Gender).Where(x => x.DeletedOn.HasValue == false).OrderBy(x => x.Id).Take(firstTake);
                foreach (var user in users)
                {
                    var dto = Mapper.Map<User, UserDto>(user);
                    UserDictionary.TryAdd(user.Email, dto);
                    UserByIdDictionary.TryAdd(user.Id, dto);
                }
            });
            usersTask1.Start();

            var usersTask2 = new Task(() =>
            {
                var users = this.db.Users.Include(x => x.UserType).Include(x => x.Gender).Where(x => x.DeletedOn.HasValue == false).OrderBy(x => x.Id).Skip(firstTake).Take(secondTake);
                foreach (var user in users)
                {
                    var dto = Mapper.Map<User, UserDto>(user);
                    UserDictionary.TryAdd(user.Email, dto);
                    UserByIdDictionary.TryAdd(user.Id, dto);
                }
            });
            usersTask2.Start();

            Task.WaitAll(userLoginTask, usersTask1, usersTask2);
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
        public bool AddAddress(AddressDto dto)
        {
            if (!this.db.Addresses.Any(x => x.DeletedOn.HasValue == false && x.UserId == dto.User.Id && x.Name.Trim() == dto.Name.Trim()))
            {
                this.db.Addresses.Add(new Address
                    {
                        Name=dto.Name,
                        AddressText=dto.AddressText,
                        District=dto.District,
                        CountyId=dto.County.Id,
                        CityId=dto.City.Id,
                        GeoZoneId=dto.GeoZone.Id,
                        CountryId=dto.Country.Id,
                        PostalCode=dto.PostalCode,
                        Coordinates=dto.Coordinates,
                        PersonName=dto.PersonName,
                        PrimaryPhone=dto.PrimaryPhone,
                        CompanyName=dto.CompanyName,
                        TaxNumber=dto.TaxNumber,
                        TaxOffice=dto.TaxOffice,
                        IsApproved=dto.IsApproved,
                        IsCompany=dto.IsCompany,
                        UserId=dto.User.Id,
                        SupplierId=dto.Supplier.Id,
                        SupplierEmployeeId=dto.SupplierEmployee.Id
                    });
                this.db.SaveChanges();
                return true;
            }

            return false;
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
            var address = this.db.Addresses.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.User.Id && x.Name.Trim() == dto.Name.Trim());

            if (address != null)
            {
                address.Name = dto.Name;
                address.AddressText = dto.AddressText;
                address.District = dto.District;
                address.CountyId = dto.County.Id;
                address.CityId = dto.City.Id;
                address.CountryId = dto.Country.Id;
                address.PostalCode = dto.PostalCode;
                address.CompanyName = dto.CompanyName;
                address.Coordinates = dto.Coordinates;
                address.PersonName = dto.PersonName;
                address.PrimaryPhone = dto.PrimaryPhone;
                address.TaxNumber = dto.TaxNumber;
                address.TaxOffice = dto.TaxOffice;
                address.IsApproved = dto.IsApproved;
                address.IsCompany = dto.IsCompany;
                address.Comment = dto.Comment;
                address.UpdatedOn = DateTime.Now;
                address.UpdatedBy = dto.UpdatedBy;

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
            var address = this.db.Addresses.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id && x.Name.Trim() == dto.Name.Trim());
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
            var phone = this.db.Phones.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == dto.Id && x.Telephone.Trim() == dto.Telephone.Trim());
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
            int id = GetUserIdByEmail(email);
            var addresses = this.db.Addresses.Include(x => x.User)
                        .Include(x => x.County)
                        .Include(x => x.City)
                        .Where(x => x.DeletedOn.HasValue == false && x.Id == id);

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
    }
}
