using System.Runtime.Serialization;

namespace Membership.Contract
{
    [DataContract]
    public class CountryDto : BaseDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ShortName { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
    }
}