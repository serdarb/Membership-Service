using System;

namespace Membership.Data
{
    [Serializable]
    public class EmployeeAdminRole : BaseEntity
    {
        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }

        public AdminRole AdminRole { get; set; }
        public int? AdminRoleId { get; set; }
    }
}
