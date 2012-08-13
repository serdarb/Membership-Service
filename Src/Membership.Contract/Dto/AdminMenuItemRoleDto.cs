namespace Membership.Contract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class AdminMenuItemRoleDto : BaseDto
    {
        [DataMember]
        public AdminMenuItemDto AdminMenuItem { get; set; }
        [DataMember]
        public AdminRoleDto AdminRole { get; set; }
    }
}
