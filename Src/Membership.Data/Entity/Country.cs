namespace Membership.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class Country : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string ShortName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string CountryCode { get; set; }        
    }
}