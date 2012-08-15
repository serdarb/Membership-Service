using System.ServiceModel;

namespace Membership.Contract
{
    [ServiceContract]
    public interface ISupplierEmployeeMembershipService
    {
        [OperationContract]
        bool AuthSupplierEmployee(string userName, string password);

        [OperationContract]
        int CreateSupplierEmployee(SupplierEmployeeDto dto);
        
        [OperationContract]
        bool DeleteSupplierEmployee(SupplierEmployeeDto dto);

        [OperationContract]
        bool RequestPasswordResetForSupplierEmployee(string email);

        [OperationContract]
        bool ChangePasswordForSupplierEmployee(string email, string newPasswordHash);

        [OperationContract]
        bool AddAddress(AddressDto dto);

        [OperationContract]
        bool AddPhone(PhoneDto dto);

        [OperationContract]
        SupplierEmployeeDto GetSupplierEmployeeById(int id);

        [OperationContract]
        SupplierEmployeeDto GetSupplierEmployee(string email);
    }
}
