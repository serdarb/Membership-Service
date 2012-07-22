using System;

namespace Membership.Data
{
    [Serializable]
    public class GeoZone : BaseEntity
    {
        public string Name { get; set; }

        public Country Country { get; set; }
        public int? CountryId { get; set; }
    }
}