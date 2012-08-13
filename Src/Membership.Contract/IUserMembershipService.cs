using System.ServiceModel;
using System.Collections.Generic;

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
        int GetUserIdByEmail(string email);
        
        [OperationContract]
        string GetUserEmailById(string id);

        [OperationContract]
        UserDto GetUserById(int id);

        [OperationContract]
        UserDto GetUser(string email);

        [OperationContract]
        bool DeleteUser(string email);

        [OperationContract]
        bool RequestPasswordReset(string email);

        [OperationContract]
        bool ChangePassword(string email, string newPasswordHash);

        [OperationContract]
        bool InviteUser(string refererUserEmail, string invitedEmail);

        [OperationContract]
        bool ChangeAffiliateSlug(string slug);
                
        [OperationContract]
        bool AddAddress(AddressDto dto);

        [OperationContract]
        bool AddPhone(PhoneDto dto);

        [OperationContract]
        bool UpdateAddress(AddressDto dto);

        [OperationContract]
        bool UpdatePhone(PhoneDto dto);

        [OperationContract]
        bool DeleteAddress(AddressDto dto);

        [OperationContract]
        bool DeletePhone(PhoneDto dto);

        [OperationContract]
        List<PhoneDto> GetPhones(string email);

        [OperationContract]
        List<PhoneDto> GetPhonesByUserId(int id);

        [OperationContract]
        List<AddressDto> GetAddresses(string email);

        [OperationContract]
        List<AddressDto> GetAddressesByUserId(int id);
      
    }
}
