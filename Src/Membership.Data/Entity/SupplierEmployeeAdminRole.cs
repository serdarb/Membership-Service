namespace Membership.Data.Entity
{
    using System;

    [Serializable]
    public class SupplierEmployeeAdminRole : BaseEntity
    {
        public SupplierEmployee SupplierEmployee { get; set; }
        public int? SupplierEmployeeId { get; set; }

        public AdminRole AdminRole { get; set; }
        public int? AdminRoleId { get; set; }

        public string Expression { get; set; }
    }
}
