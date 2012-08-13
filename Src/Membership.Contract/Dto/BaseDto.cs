namespace Membership.Contract
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class BaseDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public int UpdatedBy { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
        [DataMember]
        public DateTime UpdatedOn { get; set; }
        [DataMember]
        public DateTime? DeletedOn { get; set; }
    }
}
