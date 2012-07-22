using System;
using System.Runtime.Serialization;

namespace Membership.Contract
{
    [DataContract]
    public class BaseDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public int LastUpdatedBy { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime UpdatedOn { get; set; }
        [DataMember]
        public DateTime? DeletedOn { get; set; }
    }
}
