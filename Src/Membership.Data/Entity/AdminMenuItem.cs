using System;

namespace Membership.Data
{
    [Serializable]
    public class AdminMenuItem : BaseEntity 
    {
        public AdminMenuItemGroup AdminMenuItemGroup { get; set; }
        public int? AdminMenuItemGroupId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string NavigateUrl { get; set; }

        public int DisplayOrder { get; set; }
    }
}
