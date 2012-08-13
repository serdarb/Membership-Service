namespace Membership.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class County : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public City City { get; set; }
        public int? CityId { get; set; }
    }
}