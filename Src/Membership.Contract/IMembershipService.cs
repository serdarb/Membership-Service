using System.ServiceModel;

namespace Membership.Contract
{
    [ServiceContract]
    public interface IMembershipService
    {
        [OperationContract]
        bool AuthUser(string userName, string password);
        [OperationContract]
        bool AuthEmployee(string userName, string password);
        [OperationContract]
        bool AuthSupplierEmployee(string userName, string password);

        [OperationContract]
        int CreateUser(UserDto dto);
        [OperationContract]
        int CreateEmployee(EmployeeDto dto);
        [OperationContract]
        int CreateSupplierEmployee(SupplierEmployeeDto dto);

        [OperationContract]
        bool DoesUserEmailExists(string email);

        [OperationContract]
        bool DeleteUser(string email);
        [OperationContract]
        bool DeleteEmployee(string email);
        [OperationContract]
        bool DeleteSupplierEmployee(string email);

        [OperationContract]
        bool RequestPasswordResetForUser(string email);
        [OperationContract]
        bool RequestPasswordResetForEmployee(string email);
        [OperationContract]
        bool RequestPasswordResetForSupplierEmployee(string email);

        [OperationContract]
        bool ChangePasswordForUser(string email, string newPasswordHash);
        [OperationContract]
        bool ChangePasswordForEmployee(string email, string newPasswordHash);
        [OperationContract]
        bool ChangePasswordForSupplierEmployee(string email, string newPasswordHash);

        [OperationContract]
        bool AddAddress(AddressDto dto);
        [OperationContract]
        bool AddPhone(PhoneDto dto);

        [OperationContract]
        bool InviteUser(string refererUserEmail, string invitedEmail);

        [OperationContract]
        UserDto GetUserById(int id);
        [OperationContract]
        UserDto GetUser(string email);

        [OperationContract]
        EmployeeDto GetEmployeeById(int id);
        [OperationContract]
        EmployeeDto GetEmployee(string email);

        [OperationContract]
        SupplierEmployeeDto GetSupplierEmployeeById(int id);
        [OperationContract]
        SupplierEmployeeDto GetSupplierEmployee(string email);
    }
}
