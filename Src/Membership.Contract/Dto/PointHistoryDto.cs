﻿namespace Membership.Contract
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class PointHistoryDto : BaseDto
    {
        [DataMember]
        public UserDto User { get; set; }

        [DataMember]
        public PointTypeDto PointType { get; set; }

        [DataMember]
        public int Point { get; set; }

        [DataMember]
        public string Expression { get; set; }
    }
}
