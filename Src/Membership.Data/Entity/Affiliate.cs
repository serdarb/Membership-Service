namespace Membership.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class Affiliate : BaseEntity
    {
        [Required(AllowEmptyStrings = false), StringLength(255)]
        public string Email { get; set; }

        //invited user
        public User User { get; set; }
        public int? UserId { get; set; }

        public string RefererSource { get; set; }

        public DateTime? ActivatedOn { get; set; }
    }
}