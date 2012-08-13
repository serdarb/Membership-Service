namespace Membership.Data.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class User : BaseEntity
    {
        [Required(AllowEmptyStrings = false), StringLength(255)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PasswordHash { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Names { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string IdentityNumber { get; set; }

        public DateTime? Birthday { get; set; }
        public string Website { get; set; }
        public string FacebookId { get; set; }
        public string TwitterId { get; set; }
        public string PinterestId { get; set; }
        public string SkypeId { get; set; }
        public string PhotoUrl { get; set; }

        public bool IsActive { get; set; }
        public bool IsMailingActive { get; set; }
        public bool IsOtherMailingActive { get; set; }

        public int VirtualMoney { get; set; }
        public int Point { get; set; }

        public string AffiliateSlug { get; set; }
        public string RefererSource { get; set; }

        public string LastInvoiceAddressId { get; set; }
        public string LastShippingAddressId { get; set; }

        public UserType UserType { get; set; }
        public int? UserTypeId { get; set; }

        public Gender Gender { get; set; }
        public int? GenderId { get; set; }

        public DateTime? PasswordResetRequestedOn { get; set; }
        public string PasswordResetToken { get; set; }
    }
}