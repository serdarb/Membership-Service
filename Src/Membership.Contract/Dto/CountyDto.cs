using System.Runtime.Serialization;

namespace Membership.Contract
{
    [DataContract]
    public class CountyDto : BaseDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public CityDto City { get; set; }
    }
}