using System.ServiceModel;

namespace Membership.Contract
{
    [ServiceContract]
    public interface IUserMembershipService
    {
        [OperationContract]
        bool AuthUser(string userName, string password);
       
        [OperationContract]
        int CreateUser(UserDto dto);

        [OperationContract]
        bool DoesUserEmailExists(string email);

        [OperationContract]
        bool DeleteUser(string email);

        [OperationContract]
        bool RequestPasswordResetForUser(string email);

        [OperationContract]
        bool ChangePasswordForUser(string email, string newPasswordHash);

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
    }
}
