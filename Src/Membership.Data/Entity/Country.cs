using System;

namespace Membership.Data
{
    [Serializable]
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string CountryCode { get; set; }
    }
}