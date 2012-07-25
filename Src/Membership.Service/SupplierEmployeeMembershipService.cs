﻿namespace Membership.Service
{
    using System;

    using Membership.Contract;

    /// <summary>
    /// The supplier employee membership service.
    /// </summary>
    public class SupplierEmployeeMembershipService : ISupplierEmployeeMembershipService
    {
        public bool AuthSupplierEmployee(string userName, string password)
        {
            throw new NotImplementedException();
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
