namespace Membership.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class SupplierEmployee : BaseEntity
    {
        public User User { get; set; }
        public int? UserId { get; set; }

        public Supplier Supplier { get; set; }
        public int? SupplierId { get; set; }

        [Required(AllowEmptyStrings = false), StringLength(255)]
        public string Email { get; set; }
        public string PrimaryPhone { get; set; }
        
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public string Department { get; set; }

        public DateTime? PasswordResetRequestedOn { get; set; }
        public string PasswordResetToken { get; set; }
    }
}