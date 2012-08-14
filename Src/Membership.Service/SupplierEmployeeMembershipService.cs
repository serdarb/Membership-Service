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

        public bool DeleteSupplierEmployee(string email)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
