using System.Runtime.Serialization;

namespace Membership.Contract
{
    [DataContract]
    public class GenderDto : BaseDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}