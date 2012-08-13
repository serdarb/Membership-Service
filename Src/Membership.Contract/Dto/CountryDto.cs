namespace Membership.Contract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CountryDto : BaseDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ShortName { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
    }
}