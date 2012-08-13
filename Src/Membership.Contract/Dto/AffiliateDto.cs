namespace Membership.Contract
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class AffiliateDto : BaseDto
    {
        [DataMember]
        public string Email { get; set; }
        
        //invited user
        [DataMember]
        public UserDto User { get; set; }

        [DataMember]
        public string RefererSource { get; set; }

        [DataMember]
        public DateTime ActivatedOn { get; set; }
    }
}