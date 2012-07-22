using System.Runtime.Serialization;

namespace Membership.Contract
{
    [DataContract]
    public class SupplierEmployeeDto : BaseDto
    {
        [DataMember]
        public UserDto User { get; set; }

        [DataMember]
        public SupplierDto Supplier { get; set; }

        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PrimaryPhone { get; set; }

        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string PasswordHash { get; set; }

        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public string NewPasswordHash { get; set; }
    }
}