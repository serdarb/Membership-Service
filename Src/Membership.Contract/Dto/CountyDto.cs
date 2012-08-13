namespace Membership.Contract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CountyDto : BaseDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public CityDto City { get; set; }
    }
}