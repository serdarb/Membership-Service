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
    /// The employee membership service.
    /// </summary>
    public class EmployeeMembershipService : BaseMembershipService, IEmployeeMembershipService
    {
        public bool AuthEmployee(string userName, string password)
        {
            return db.Employees.Any(x => x.DeletedOn.HasValue == false &&
                                         x.PasswordHash == password &&
                                         (x.UserName == userName || x.Email == userName));
        }

        public int CreateEmployee(EmployeeDto dto)
        {
            if (!this.db.Employees.Any(x => x.DeletedOn.HasValue == false && x.Email.Trim() == dto.Email.Trim()))
            {
                this.db.Employees.Add(new Employee
                {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = 1,
                    Comment = dto.Comment,
                    UserId = dto.User.Id,
                    Email = dto.Email,
                    UserName = dto.UserName,
                    PasswordHash = dto.PasswordHash,
                    PrimaryPhone = dto.PrimaryPhone,
                    Department = dto.Department
                });
                this.db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public bool DeleteEmployee(EmployeeDto dto)
        {
            var employee = this.db.Employees.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email.Trim() == dto.Email.Trim());
            if (employee != null)
            {
                employee.DeletedOn = DateTime.Now;
                employee.UpdatedBy = dto.User.Id;
                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RequestPasswordResetForEmployee(string email)
        {
            var guid = Guid.NewGuid().ToString().Replace("-", string.Empty);

            var Employee = this.db.Employees.First(x => x.Email == email);
            Employee.UpdatedOn = DateTime.Now;
            Employee.UpdatedBy = Employee.Id;
            Employee.PasswordResetToken = guid;
            Employee.PasswordResetRequestedOn = DateTime.Now;

            this.db.SaveChanges();

            //todo: send password reset mail

            return true;
        }

        public bool ChangePasswordForEmployee(string email, string newPasswordHash)
        {
            var employee = this.db.Employees
                .Include(x => x.User)
                .FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email.Trim() == email.Trim());
            if (employee != null)
            {
                employee.PasswordHash = newPasswordHash;
                employee.UpdatedOn = DateTime.Now;
                employee.UpdatedBy = employee.User.Id;

                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool IsPasswordResetRequestValid(string email, string guid)
        {
            var Employee = this.db.Employees
                            .Include(x => x.User)
                            .FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email.Trim() == email.Trim());
            if (Employee != null)
            {
                if (guid != null && Employee.PasswordResetToken == guid.Trim())
                {
                    if (Employee.PasswordResetRequestedOn.HasValue)
                    {
                        if (Employee.PasswordResetRequestedOn.Value.AddDays(1) > DateTime.Now)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool AddAddress(AddressDto dto)
        {
            if (!this.db.Addresses.Any(x => x.DeletedOn.HasValue == false && x.Name.Trim() == dto.Name.Trim()))
            {
                this.db.Addresses.Add(new Address
                {
                    Name = dto.Name,
                    AddressText = dto.AddressText,
                    District = dto.District,
                    CountyId = dto.County.Id,
                    CityId = dto.City.Id,
                    GeoZoneId = dto.GeoZone.Id,
                    CountryId = dto.Country.Id,
                    PostalCode = dto.PostalCode,
                    Coordinates = dto.Coordinates,
                    PersonName = dto.PersonName,
                    PrimaryPhone = dto.PrimaryPhone,
                    CompanyName = dto.CompanyName,
                    TaxNumber = dto.TaxNumber,
                    TaxOffice = dto.TaxOffice,
                    IsApproved = dto.IsApproved,
                    IsCompany = dto.IsCompany,
                    UserId = dto.User.Id,
                    UpdatedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    UpdatedBy = dto.UpdatedBy,
                    Comment = dto.Comment
                });
                this.db.SaveChanges();

                return true;
            }
            return false;

        }

        public bool AddPhone(PhoneDto dto)
        {
            if (!this.db.Phones.Any(x => x.DeletedOn.HasValue == false && x.Telephone.Trim() == dto.Telephone.Trim()))
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
                return true;
            }

            return false;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = this.db.Employees
                .Include(x => x.User)
                .FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == id);

            if (employee != null)
            {
                return Mapper.Map<Employee, EmployeeDto>(employee);
            }

            return null;

        }

        public EmployeeDto GetEmployee(string email)
        {
            var employee = this.db.Employees.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email.Trim() == email.Trim());

            if (employee != null)
            {
                return Mapper.Map<Employee, EmployeeDto>(employee);
            }

            return null;
        }

        public int GetEmployeeIdByEmailorUserName(string emailorUserName)
        {
            var employee = this.db.Employees.FirstOrDefault(x => x.DeletedOn.HasValue == false &&
                                                           (x.UserName == emailorUserName || x.Email == emailorUserName));
            if (employee != null)
            {
                return employee.Id;
            }
            return 0;
        }

        public List<EmployeeDto> GetEmployees()
        {
            var employees= this.db.Employees.Where(x => x.DeletedOn.HasValue == false);
            var dtos=new List<EmployeeDto>();
            foreach (var employee in employees)
            {
                dtos.Add(Mapper.Map<Employee, EmployeeDto>(employee));
            }
            return dtos;

        }
    }
}
