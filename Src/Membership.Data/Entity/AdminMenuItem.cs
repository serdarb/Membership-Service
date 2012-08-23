namespace Membership.Data.Entity
{
    using System;

    [Serializable]
    public class AdminMenuItem : BaseEntity
    {
        public AdminMenuItem ParentAdminMenuItem { get; set; }
        public int? ParentAdminMenuItemId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string NavigateUrl { get; set; }

        public int DisplayOrder { get; set; }
    }
}
