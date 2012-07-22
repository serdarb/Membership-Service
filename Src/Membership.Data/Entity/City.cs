using System;

namespace Membership.Data
{
    [Serializable]
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public GeoZone GeoZone { get; set; }
        public int? GeoZoneId { get; set; }
    }
}