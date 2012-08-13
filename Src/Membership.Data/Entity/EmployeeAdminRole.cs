namespace Membership.Data.Entity
{
    using System;

    [Serializable]
    public class EmployeeAdminRole : BaseEntity
    {
        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }

        public AdminRole AdminRole { get; set; }
        public int? AdminRoleId { get; set; }

        public string Expression { get; set; }
    }
}
