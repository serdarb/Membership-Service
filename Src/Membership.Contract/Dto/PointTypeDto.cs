namespace Membership.Contract
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class PointTypeDto : BaseDto
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Point { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

    }
}
