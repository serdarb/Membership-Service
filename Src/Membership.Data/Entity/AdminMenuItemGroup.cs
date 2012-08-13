namespace Membership.Data.Entity
{
    using System;

    [Serializable]
    public class AdminMenuItemGroup : BaseEntity
    {
        public AdminMenuItemGroup ParentAdminMenuItemGroup { get; set; }
        public int? ParentAdminMenuItemGroupId { get; set; } 
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string NavigateUrl { get; set; }

        public int DisplayOrder { get; set; }
    }
}
