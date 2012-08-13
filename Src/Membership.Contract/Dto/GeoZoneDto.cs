namespace Membership.Contract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class GeoZoneDto : BaseDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public CountryDto Country { get; set; }
    }
}