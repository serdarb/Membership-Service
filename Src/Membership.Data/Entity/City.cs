namespace Membership.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class City : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public GeoZone GeoZone { get; set; }
        public int? GeoZoneId { get; set; }
    }
}