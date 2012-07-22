using System;

namespace Membership.Data
{
    [Serializable]
    public class SupplierEmployee : BaseEntity
    {
        public User User { get; set; }
        public int? UserId { get; set; }

        public Supplier Supplier { get; set; }
        public int? SupplierId { get; set; }

        public string Email { get; set; }
        public string PrimaryPhone { get; set; }
        
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public string Department { get; set; }
    }
}