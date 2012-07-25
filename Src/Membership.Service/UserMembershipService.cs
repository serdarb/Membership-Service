using System;
using System.Collections.Concurrent;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Membership.Contract;
using Membership.Data;
using Membership.Utils.Encryption;

namespace Membership.Service
{
    public class UserMembershipService : IUserMembershipService
    {
        private readonly EmployeeAssembler _employeeAssembler;
        private readonly SupplierEmployeeAssembler _supplierEmployeeAssembler;
        private readonly UserAssembler _userAssembler;
        private readonly CryptographyHelper _cryptographyHelper;

        private ConcurrentDictionary<string, string> UserLoginDictionary { get; set; }
        private ConcurrentDictionary<string, UserDto> UserDictionary { get; set; }
        private ConcurrentDictionary<int, UserDto> UserByIdDictionary { get; set; }
        private ConcurrentDictionary<string, EmployeeDto> EmployeeDictionary { get; set; }
        private ConcurrentDictionary<string, SupplierEmployeeDto> SupplierEmployeeDictionary { get; set; }

        private MembershipDB db = new MembershipDB();

        public UserMembershipService(EmployeeAssembler employeeAssembler,
                                     SupplierEmployeeAssembler supplierEmployeeAssembler,
                                     UserAssembler userAssembler,
                                     CryptographyHelper cryptographyHelper)
        {
            _employeeAssembler = employeeAssembler;
            _supplierEmployeeAssembler = supplierEmployeeAssembler;
            _userAssembler = userAssembler;
            _cryptographyHelper = cryptographyHelper;

            UserDictionary = new ConcurrentDictionary<string, UserDto>();
            EmployeeDictionary = new ConcurrentDictionary<string, EmployeeDto>();
            SupplierEmployeeDictionary = new ConcurrentDictionary<string, SupplierEmployeeDto>();
            UserLoginDictionary = new ConcurrentDictionary<string, string>();

            var userLoginTask = new Task(() =>
            {
                var userLogin = db.Users.Where(x => x.DeletedOn.HasValue == false).Select(user => new { user.Email, user.PasswordHash });
                foreach (var user in userLogin)
                {
                    UserLoginDictionary.TryAdd(user.Email, user.PasswordHash);

                }
            });
            userLoginTask.Start();

            var usersTask = new Task(() =>
            {
                var users = db.Users.Include(x => x.UserType).Include(x => x.Gender).Where(x => x.DeletedOn.HasValue == false);
                foreach (var user in users)
                {
                    var dto = _userAssembler.Assemble(user);
                    UserDictionary.TryAdd(user.Email, dto);
                    UserByIdDictionary.TryAdd(user.Id, dto);
                }
            });
            usersTask.Start();

            var employeesTask = new Task(() =>
            {
                var employees = db.Employees.Include(x => x.User).Where(x => x.DeletedOn.HasValue == false);
                var supplierEmployees = db.SupplierEmployees.Include(x => x.User).Include(x => x.Supplier).Where(x => x.DeletedOn.HasValue == false);

                foreach (var employee in employees)
                {
                    EmployeeDictionary.TryAdd(employee.Email, _employeeAssembler.Assemble(employee));
                }

                foreach (var supplierEmployee in supplierEmployees)
                {
                    SupplierEmployeeDictionary.TryAdd(supplierEmployee.Email, _supplierEmployeeAssembler.Assemble(supplierEmployee));
                }
            });
            employeesTask.Start();

            Task.WaitAll(userLoginTask, usersTask, employeesTask);
        }

        public bool AuthUser(string userName, string password)
        {
            var auth = false;
            if (DoesUserEmailExists(userName))
            {
                var passhwordHash = _cryptographyHelper.SHA256Hasher(password);
                auth = UserLoginDictionary[userName] == passhwordHash;
            }

            return auth;
        }

        public int CreateUser(UserDto dto)
        {
            if (!DoesUserEmailExists(dto.Email))
            {
                var gender = db.Genders.First(x => x.Id == dto.Gender.Id);
                var userType = db.UserTypes.First(x => x.Id == dto.UserType.Id);

                db.Users.Add(new User
                                 {
                                     CreatedOn = DateTime.Now,
                                     UpdatedOn = DateTime.Now,
                                     LastUpdatedBy = 1,
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
                db.SaveChanges();

                var user = db.Users.FirstOrDefault(x => x.Email == dto.Email);
                if (user != null)
                {
                    UserLoginDictionary.TryAdd(user.Email, user.PasswordHash);

                    var userDto = _userAssembler.Assemble(user);
                    UserDictionary.TryAdd(user.Email, userDto);

                    return user.Id;
                }
            }

            return 0;
        }

        public bool DoesUserEmailExists(string email)
        {
            return UserLoginDictionary.ContainsKey(email); ;
        }

        public bool DeleteUser(string email)
        {
            if (!UserLoginDictionary.ContainsKey(email))
            {
                var user = db.Users.FirstOrDefault(x => x.Email == email);
                if (user != null)
                {
                    user.DeletedOn = DateTime.Now;
                    user.LastUpdatedBy = user.Id;

                    db.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public bool RequestPasswordResetForUser(string email)
        {
            if (DoesUserEmailExists(email))
            {
                var guid = Guid.NewGuid().ToString().Replace("-", "");

                var user = db.Users.First(x => x.Email == email);
                user.UpdatedOn = DateTime.Now;
                user.LastUpdatedBy = user.Id;
                user.PasswordResetToken = guid;
                user.PasswordResetRequestedOn = DateTime.Now;

                db.SaveChanges();

                //todo: send password reset mail

                return true;
            }

            return false;

        }

        public bool ChangePasswordForUser(string email, string newPasswordHash)
        {
            if (DoesUserEmailExists(email))
            {
                var user = db.Users.First(x => x.Email == email);
                if (user != null)
                {
                    user.PasswordHash = newPasswordHash;
                    user.LastUpdatedBy = user.Id;
                    user.UpdatedOn = DateTime.Now;

                    db.SaveChanges();

                    UserDictionary[email] = _userAssembler.Assemble(user);
                    UserLoginDictionary[email] = newPasswordHash;

                    return true;
                }
            }

            return false;
        }

        public bool AddAddress(AddressDto dto)
        {
            throw new NotImplementedException();
        }

        public bool AddPhone(PhoneDto dto)
        {
            throw new NotImplementedException();
        }

        public bool InviteUser(string refererUserEmail, string invitedEmail)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(string email)
        {
            UserDto user = null;
            if (DoesUserEmailExists(email))
            {
                user = UserDictionary[email];
            }

            return user;
        }
    }
}
