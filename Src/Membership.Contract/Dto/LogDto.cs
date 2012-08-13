namespace Membership.Contract
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class LogDto : BaseDto
    {
        [DataMember]
        public LogEventDto LogEvent { get; set; }

        [DataMember]
        public string Expression { get; set; }
        [DataMember]
        public string OldRow { get; set; }
        [DataMember]
        public string NewRow { get; set; }
    }
}