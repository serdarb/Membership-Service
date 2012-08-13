namespace Membership.Service
{
    using System;

    using Membership.Contract;

    /// <summary>
    /// The employee membership service.
    /// </summary>
    public class EmployeeMembershipService : IEmployeeMembershipService
    {


        public bool AuthEmployee(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public int CreateEmployee(EmployeeDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(string email)
        {
            throw new NotImplementedException();
        }

        public bool RequestPasswordResetForEmployee(string email)
        {
            throw new NotImplementedException();
        }

        public bool ChangePasswordForEmployee(string email, string newPasswordHash)
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

        public EmployeeDto GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeeDto GetEmployee(string email)
        {
            throw new NotImplementedException();
        }
    }
}
