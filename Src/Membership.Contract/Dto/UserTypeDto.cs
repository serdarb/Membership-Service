namespace Membership.Contract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserTypeDto : BaseDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}