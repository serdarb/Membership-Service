namespace Membership.Data.Entity
{
    using System;

    [Serializable]
    public class Log : BaseEntity
    {
        public LogEvent LogEvent { get; set; }
        public int? LogEventId { get; set; }

        public string Expression { get; set; }
        public string OldRow { get; set; }
        public string NewRow { get; set; }
    }
}