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
        private ConcurrentDictionary<string, EmployeeDto> EmployeeDictionary { get; set; }
        private ConcurrentDictionary<string, SupplierEmployeeDto> SupplierEmployeeDictionary { get; set; }

        private MembershipDB db = new MembershipDB();

        public UserMembershipService()
        {
            AutoMapperConfiguration.CreateMaps();

            this.UserDictionary = new ConcurrentDictionary<string, UserDto>();
            this.UserLoginDictionary = new ConcurrentDictionary<string, string>();
            this.UserByIdDictionary = new ConcurrentDictionary<int, UserDto>();
            this.EmployeeDictionary = new ConcurrentDictionary<string, EmployeeDto>();
            this.SupplierEmployeeDictionary = new ConcurrentDictionary<string, SupplierEmployeeDto>();

            var userLogin = this.db.Users.Where(x => x.DeletedOn.HasValue == false).Select(user => new { user.Email, user.PasswordHash });
            foreach (var user in userLogin)
            {
                this.UserLoginDictionary.TryAdd(user.Email, user.PasswordHash);
            }

            var usersTask = new Task(() =>
            {
                var users = this.db.Users.Include(x => x.UserType).Include(x => x.Gender).Where(x => x.DeletedOn.HasValue == false);
                foreach (var user in users)
                {
                    var dto = Mapper.Map<User, UserDto>(user);
                    UserDictionary.TryAdd(user.Email, dto);
                    UserByIdDictionary.TryAdd(user.Id, dto);
                }
            });
            usersTask.Start();

            var employeesTask = new Task(() =>
            {
                var employees = this.db.Employees.Include(x => x.User).Where(x => x.DeletedOn.HasValue == false);
                var supplierEmployees = this.db.SupplierEmployees.Include(x => x.User).Include(x => x.Supplier).Where(x => x.DeletedOn.HasValue == false);

                foreach (var employee in employees)
                {
                    var dto = Mapper.Map<Employee, EmployeeDto>(employee);
                    EmployeeDictionary.TryAdd(employee.Email, dto);
                }

                foreach (var supplierEmployee in supplierEmployees)
                {
                    var dto = Mapper.Map<SupplierEmployee, SupplierEmployeeDto>(supplierEmployee);
                    SupplierEmployeeDictionary.TryAdd(supplierEmployee.Email, dto);
                }
            });
            employeesTask.Start();

            Task.WaitAll(usersTask, employeesTask);
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
                var gender = this.db.Genders.First(x => x.Id == dto.Gender.Id);
                var userType = this.db.UserTypes.First(x => x.Id == dto.UserType.Id);

                this.db.Users.Add(new User
                                 {
                                     CreatedOn = DateTime.Now,
                                     UpdatedOn = DateTime.Now,
                                     UpdatedBy = 1,
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
                                     Gender = gender,
                                     UserType = userType,
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
            db.Addresses.Add(Mapper.Map<AddressDto, Address>(dto));
            return db.SaveChanges() > 0;
        }

        public bool AddPhone(PhoneDto dto)
        {
            db.Phones.Add(Mapper.Map<PhoneDto, Phone>(dto));
            return db.SaveChanges() > 0;
        }

        public bool InviteUser(string refererUserEmail, string invitedEmail)
        {
            throw new NotImplementedException();
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

        public bool ChangeAffiliateSlug(string slug)
        {
            throw new NotImplementedException();
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
            var address = db.Addresses.First(x => x.DeletedOn.HasValue == false && x.Id == dto.User.Id);

            if (address != null)
            {
                address.Name = dto.Name;
                address.AddressText = dto.AddressText;
                address.District = dto.District;
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

                db.SaveChanges();
                   
                return true;
            }

            return false;

        }

        public bool UpdatePhone(PhoneDto dto)
        {
            var phone = db.Phones.First(x => x.DeletedOn.HasValue == false && x.UserId == dto.User.Id);

            if (phone != null)
            {
                phone.Telephone = dto.Telephone;
                phone.IsFax = dto.IsFax;
                phone.IsPrimary = dto.IsPrimary;
                phone.UpdatedOn = DateTime.Now;
                phone.UpdatedBy = dto.UpdatedBy;
                phone.Comment = dto.Comment;

                db.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DeleteAddress(AddressDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeletePhone(PhoneDto dto)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<PhoneDto> GetPhones(string email)
        {
            var id = GetUserIdByEmail(email);

            var phones = db.Phones.Include(x => x.User)
                .Where(x => x.UserId == id);

            var dtos = new List<PhoneDto>();
            foreach (var phone in phones)
            {
                dtos.Add(Mapper.Map<Phone, PhoneDto>(phone));
            }

            return dtos;
        }

        public List<PhoneDto> GetPhonesByUserId(int id)
        {
            var phones = db.Phones.Include(x => x.User)
                .Where(x => x.DeletedOn.HasValue == false && x.UserId == id);

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
            var addresses = db.Addresses.Include(x => x.User)
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
            var addresses = db.Addresses.Include(x => x.User)
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
