using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Membership.Contract;

namespace Membership.Service
{
    public partial class MembershipService : IMembershipService
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



        public bool ChangePasswordForSupplierEmployee(string email)
        {
            throw new NotImplementedException();
        }

      

        public SupplierEmployeeDto GetSupplierEmployee(string email)
        {
            throw new NotImplementedException();
        }

       

        public SupplierEmployeeDto GetSupplierEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
