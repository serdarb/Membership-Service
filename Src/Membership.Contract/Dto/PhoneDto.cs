using System.Runtime.Serialization;

namespace Membership.Contract
{
    [DataContract]
    public class PhoneDto : BaseDto
    {
        [DataMember]
        public string Telephone { get; set; }

        [DataMember]
        public bool IsFax { get; set; }
        [DataMember]
        public bool IsPrimary { get; set; }

        [DataMember]
        public UserDto User { get; set; }

        [DataMember]
        public EmployeeDto Employee { get; set; }

        [DataMember]
        public SupplierEmployeeDto SupplierPerson { get; set; }

        [DataMember]
        public SupplierDto Supplier { get; set; }
    }
}