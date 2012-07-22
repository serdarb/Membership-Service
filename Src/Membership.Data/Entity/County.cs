using System;

namespace Membership.Data
{
    [Serializable]
    public class County : BaseEntity
    {
        public string Name { get; set; }

        public City City { get; set; }
        public int? CityId { get; set; }
    }
}