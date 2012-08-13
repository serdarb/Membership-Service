namespace Membership.Contract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class EmployeeAdminRoleDto : BaseDto
    {
        [DataMember]
        public EmployeeDto Employee { get; set; }
        [DataMember]
        public AdminRoleDto AdminRole { get; set; }
    }
}
