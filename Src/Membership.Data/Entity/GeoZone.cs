namespace Membership.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class GeoZone : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public Country Country { get; set; }
        public int? CountryId { get; set; }
    }
}