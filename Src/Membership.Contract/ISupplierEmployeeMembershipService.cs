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
        int CreateSupplier(SupplierDto dto);
        
        [OperationContract]
        bool DeleteSupplierEmployee(SupplierEmployeeDto dto);

        [OperationContract]
        bool RequestPasswordResetForSupplierEmployee(string email);

        [OperationContract]
        bool IsPasswordResetRequestValid(string email, string guid);

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

        [OperationContract]
        bool DoesSupplierEmployeeEmailExists(string email);

    }
}
