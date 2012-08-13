namespace Membership.Contract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class AdminMenuItemGroupDto : BaseDto
    {
        [DataMember]
        public AdminMenuItemGroupDto ParentAdminMenuItemGroup { get; set; }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string NavigateUrl { get; set; }
        [DataMember]
        public int DisplayOrder { get; set; }
    }
}
