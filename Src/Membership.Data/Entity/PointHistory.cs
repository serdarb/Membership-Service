namespace Membership.Data.Entity
{
    using System;

    [Serializable]
    public class PointHistory : BaseEntity
    {
        public User User { get; set; }
        public int? UserId { get; set; }

        public PointType PointType { get; set; }
        public int? PointTypeId { get; set; }

        public int Point { get; set; }
        public string Expression { get; set; }
    }
}