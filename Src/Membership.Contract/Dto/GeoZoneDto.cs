using System.Runtime.Serialization;

namespace Membership.Contract
{
    [DataContract]
    public class GeoZoneDto : BaseDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public CountryDto Country { get; set; }
    }
}