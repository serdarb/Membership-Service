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
    public class SupplierEmployeeMembershipService : ISupplierEmployeeMembershipService
    {
        private MembershipDB db = new MembershipDB();

        public bool AuthSupplierEmployee(string userName, string password)
        {
            return db.SupplierEmployees.Any(x => x.UserName == userName && x.PasswordHash == password && x.DeletedOn.HasValue == false);

        }

        public int CreateSupplierEmployee(SupplierEmployeeDto dto)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool ChangePasswordForSupplierEmployee(string email, string newPasswordHash)
        {
            throw new NotImplementedException();
        }

        public bool AddAddress(AddressDto dto)
        {
            if (!this.db.Addresses.Any(x => x.DeletedOn.HasValue == false && x.Name == dto.Name))
            {
                this.db.Addresses.Add(new Address {
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
            throw new NotImplementedException();
        }

        public SupplierEmployeeDto GetSupplierEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public SupplierEmployeeDto GetSupplierEmployee(string email)
        {
            throw new NotImplementedException();
        }
    }
}
