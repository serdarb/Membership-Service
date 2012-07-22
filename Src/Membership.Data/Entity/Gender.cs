using System;

namespace Membership.Data
{
    [Serializable]
    public class Gender : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}