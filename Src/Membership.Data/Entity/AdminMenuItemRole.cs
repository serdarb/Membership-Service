namespace Membership.Data.Entity
{
    using System;

    [Serializable]
    public class AdminMenuItemRole : BaseEntity
    {   
        public AdminMenuItem AdminMenuItem { get; set; }
        public int? AdminMenuItemId { get; set; }

        public AdminRole AdminRole { get; set; }
        public int? AdminRoleId { get; set; }
    }
}
