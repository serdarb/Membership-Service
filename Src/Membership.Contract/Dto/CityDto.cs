namespace Membership.Contract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CityDto : BaseDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public GeoZoneDto GeoZone { get; set; }
    }
}