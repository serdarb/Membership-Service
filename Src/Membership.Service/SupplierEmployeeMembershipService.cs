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
    /// The supplier employee membership service.
    /// </summary>
    public class SupplierEmployeeMembershipService : BaseMembershipService, ISupplierEmployeeMembershipService
    {

        public bool AuthSupplierEmployee(string userName, string password)
        {
            return db.SupplierEmployees.Any(x => x.UserName == userName && x.PasswordHash == password && x.DeletedOn.HasValue == false);

        }

        public int CreateSupplier(SupplierDto dto)
        {
            if (!this.db.Suppliers.Any(x => x.DeletedOn.HasValue == false && x.Name == dto.Name))
            {
                this.db.Suppliers.Add(new Supplier
                {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = 1,
                    Comment = dto.Comment,
                    Name = dto.Name,
                    ShortName = dto.ShortName,
                    Description = dto.Description,
                    Website = dto.Website,
                    LogoUrl = dto.LogoUrl,
                    TaxOffice = dto.TaxOffice,
                    TaxNumber = dto.TaxNumber,
                    PrimaryFinancialPersonName = dto.PrimaryFinancialPersonName,
                    PrimaryFinancialPersonPhone = dto.PrimaryFinancialPersonPhone,
                    PrimaryFinancialPersonGsm = dto.PrimaryPersonGsm,
                    PrimaryPersonFax = dto.PrimaryPersonFax,
                    PrimaryPersonEmail = dto.PrimaryPersonEmail
                });
                this.db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int CreateSupplierEmployee(SupplierEmployeeDto dto)
        {
            if (!this.DoesSupplierEmployeeEmailExists(dto.Email))
            {
                this.db.SupplierEmployees.Add(new SupplierEmployee
                {
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = 1,
                    Comment = dto.Comment,
                    Email = dto.Email,
                    PrimaryPhone = dto.PrimaryPhone,
                    UserName = dto.UserName,
                    PasswordHash = dto.PasswordHash,
                    Department = dto.Department,
                    SupplierId = dto.Supplier.Id
                });
                this.db.SaveChanges();
                return 1;
            }
            return 0;
        }

        public bool DeleteSupplierEmployee(SupplierEmployeeDto dto)
        {
            var supplierEmployee = this.db.SupplierEmployees.FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email == dto.Email);
            if (supplierEmployee != null)
            {
                supplierEmployee.DeletedOn = DateTime.Now;
                supplierEmployee.UpdatedBy = dto.User.Id;
                this.db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool RequestPasswordResetForSupplierEmployee(string email)
        {
            var guid = Guid.NewGuid().ToString().Replace("-", string.Empty);

            var supplierEmployee = this.db.SupplierEmployees.First(x => x.Email == email);
            supplierEmployee.UpdatedOn = DateTime.Now;
            supplierEmployee.UpdatedBy = supplierEmployee.Id;
            supplierEmployee.PasswordResetToken = guid;
            supplierEmployee.PasswordResetRequestedOn = DateTime.Now;

            this.db.SaveChanges();

            //todo: send password reset mail

            return true;

        }

        public bool IsPasswordResetRequestValid(string email, string guid)
        {
            if (this.DoesSupplierEmployeeEmailExists(email))
            {
                var supplierEmployee = this.db.SupplierEmployees
                                .Include(x => x.User)
                                .Include(x => x.Supplier)
                                .FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email.Trim() == email.Trim());
                if (supplierEmployee != null)
                {
                    if (guid != null && supplierEmployee.PasswordResetToken == guid.Trim())
                    {
                        if (supplierEmployee.PasswordResetRequestedOn.HasValue)
                        {
                            if (supplierEmployee.PasswordResetRequestedOn.Value.AddDays(1) > DateTime.Now)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool ChangePasswordForSupplierEmployee(string email, string newPasswordHash)
        {
            var supplierEmployee = this.db.SupplierEmployees
                .Include(x => x.User)
                .Include(x => x.Supplier)
                .FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email.Trim() == email.Trim());

            if (supplierEmployee != null)
            {
                supplierEmployee.PasswordHash = newPasswordHash;
                supplierEmployee.UpdatedOn = DateTime.Now;
                supplierEmployee.UpdatedBy = supplierEmployee.User.Id;

                this.db.SaveChanges();
                return true;
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

        public SupplierEmployeeDto GetSupplierEmployeeById(int id)
        {
            var supplierEmployee = this.db.SupplierEmployees
                .Include(x => x.User)
                .Include(x => x.Supplier)
                .FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Id == id);

            if (supplierEmployee != null)
            {
                return Mapper.Map<SupplierEmployee, SupplierEmployeeDto>(supplierEmployee);
            }

            return null;
        }

        public SupplierEmployeeDto GetSupplierEmployee(string email)
        {
            var supplierEmployee = this.db.SupplierEmployees
                .Include(x => x.User)
                .Include(x => x.Supplier)
                .FirstOrDefault(x => x.DeletedOn.HasValue == false && x.Email.Trim() == email.Trim());

            if (supplierEmployee != null)
            {
                return Mapper.Map<SupplierEmployee, SupplierEmployeeDto>(supplierEmployee);
            }

            return null;
        }

        public bool DoesSupplierEmployeeEmailExists(string Email)
        {
            return this.db.SupplierEmployees.Any(x => x.DeletedOn.HasValue == false && x.Email == Email);
        }
    }
}
