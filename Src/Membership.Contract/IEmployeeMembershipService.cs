using System.ServiceModel;

namespace Membership.Contract
{
    [ServiceContract]
    public interface IEmployeeMembershipService
    {
        [OperationContract]
        bool AuthEmployee(string userName, string password);
     
        [OperationContract]
        int CreateEmployee(EmployeeDto dto);
       
        [OperationContract]
        bool DeleteEmployee(string email);
       
        [OperationContract]
        bool RequestPasswordResetForEmployee(string email);
       
        [OperationContract]
        bool ChangePasswordForEmployee(string email, string newPasswordHash);
     
        [OperationContract]
        bool AddAddress(AddressDto dto);

        [OperationContract]
        bool AddPhone(PhoneDto dto);

        [OperationContract]
        EmployeeDto GetEmployeeById(int id);

        [OperationContract]
        EmployeeDto GetEmployee(string email);
    }
}
