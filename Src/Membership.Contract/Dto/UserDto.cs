namespace Membership.Contract
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class UserDto : BaseDto
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PasswordHash { get; set; }

        [DataMember]
        public string Names { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string PreferredName { get; set; }
        [DataMember]
        public string IdentityNumber { get; set; }

        [DataMember]
        public DateTime? Birthday { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public string FacebookId { get; set; }
        [DataMember]
        public string TwitterId { get; set; }
        [DataMember]
        public string PhotoUrl { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public bool IsMailingActive { get; set; }
        [DataMember]
        public bool IsOtherMailingActive { get; set; }

        [DataMember]
        public int VirtualMoney { get; set; }
        [DataMember]
        public int Point { get; set; }

        [DataMember]
        public string AffiliateSlug { get; set; }
        [DataMember]
        public string RefererSource { get; set; }

        [DataMember]
        public string LastInvoiceAddressId { get; set; }
        [DataMember]
        public string LastShippingAddressId { get; set; }

        [DataMember]
        public UserTypeDto UserType { get; set; }

        [DataMember]
        public GenderDto Gender { get; set; }

        [DataMember]
        public string NewPasswordHash { get; set; }

        [DataMember]
        public string PinterestId { get; set; }

        [DataMember]
        public string SkypeId { get; set; }

    }
}