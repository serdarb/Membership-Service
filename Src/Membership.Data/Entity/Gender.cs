namespace Membership.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class Gender : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}