using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Membership.Contract;
using Membership.Data;
using Membership.Utils;

namespace Membership.Service
{
    public class UserMembershipService : IUserMembershipService
    {
        private static readonly ReaderWriterLockSlim _lockUserDictionary = new ReaderWriterLockSlim();
        private static readonly ReaderWriterLockSlim _lockUserLoginDictionary = new ReaderWriterLockSlim();

        private Dictionary<string, UserDto> UserDictionary { get; set; }
        private Dictionary<string, string> UserLoginDictionary { get; set; }
        private Dictionary<string, EmployeeDto> EmployeeDictionary { get; set; }
        private Dictionary<string, SupplierEmployeeDto> SupplierEmployeeDictionary { get; set; }

        private MembershipDB db = new MembershipDB();
        
        public UserMembershipService()
        {
            var employeeAssembler = new EmployeeAssembler();
            var supplierEmployeeAssembler = new SupplierEmployeeAssembler();
            var userAsssembler = new UserAssembler();

            UserDictionary = new Dictionary<string, UserDto>();
            EmployeeDictionary = new Dictionary<string, EmployeeDto>();
            SupplierEmployeeDictionary = new Dictionary<string, SupplierEmployeeDto>();
            UserLoginDictionary = new Dictionary<string, string>();

            var employees = db.Employees.Include(x => x.User).Where(x => x.DeletedOn.HasValue == false);
            foreach (var employee in employees)
            {
                EmployeeDictionary.Add(employee.Email, employeeAssembler.Assemble(employee));
            }

            var supplierEmployees = db.SupplierEmployees.Include(x => x.User).Include(x => x.Supplier).Where(x => x.DeletedOn.HasValue == false);
            foreach (var supplierEmployee in supplierEmployees)
            {
                SupplierEmployeeDictionary.Add(supplierEmployee.Email, supplierEmployeeAssembler.Assemble(supplierEmployee));
            }

            var users = db.Users.Include(x => x.UserType).Include(x => x.Gender).Where(x => x.DeletedOn.HasValue == false);
            foreach (var user in users)
            {
                UserDictionary.Add(user.Email, userAsssembler.Assemble(user));
                UserLoginDictionary.Add(user.Email, user.PasswordHash);
            }
        }

        public bool AuthUser(string userName, string password)
        {
            var auth = false;
            if (DoesUserEmailExists(userName))
            {
                var chyptographyHelper = new CryptographyHelper();
                var passhwordHash = chyptographyHelper.SHA256Hasher(password);

                _lockUserLoginDictionary.EnterReadLock();
                auth = UserLoginDictionary[userName] == passhwordHash;
                _lockUserLoginDictionary.ExitReadLock();
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
                    _lockUserLoginDictionary.EnterWriteLock();
                    UserLoginDictionary.Add(user.Email, user.PasswordHash);
                    _lockUserLoginDictionary.ExitWriteLock();

                    var userAssembler = new UserAssembler();
                    var userDto = userAssembler.Assemble(user);

                    _lockUserDictionary.EnterWriteLock();
                    UserDictionary.Add(user.Email, userDto);
                    _lockUserDictionary.ExitWriteLock();

                    return user.Id;
                }
            }

            return 0;
        }
        
        public bool DoesUserEmailExists(string email)
        {
            _lockUserLoginDictionary.EnterReadLock();
            var exits = UserLoginDictionary.ContainsKey(email);
            _lockUserLoginDictionary.ExitReadLock();

            return exits;
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

                    var userAssembler = new UserAssembler();

                    _lockUserDictionary.EnterWriteLock();
                    UserDictionary[email] = userAssembler.Assemble(user);
                    _lockUserDictionary.ExitWriteLock();

                    _lockUserLoginDictionary.EnterWriteLock();
                    UserLoginDictionary[email] = newPasswordHash;
                    _lockUserLoginDictionary.ExitWriteLock();

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
                _lockUserDictionary.EnterReadLock();
                user = UserDictionary[email];
                _lockUserDictionary.ExitReadLock();
            }

            return user;
        }
    }
}
