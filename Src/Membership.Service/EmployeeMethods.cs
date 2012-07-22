using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Membership.Contract;

namespace Membership.Service
{
    public partial class MembershipService : IMembershipService
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
