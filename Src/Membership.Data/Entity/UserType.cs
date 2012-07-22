using System;

namespace Membership.Data
{
    [Serializable]
    public class UserType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}