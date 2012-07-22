using System;

namespace Membership.Data
{
    [Serializable]
    public class BaseEntity
    {
        public int Id { get; set; }

        public string Comment { get; set; }
        public int LastUpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}