namespace Membership.Data.Entity
{
    using System;

    [Serializable]
    public class Phone : BaseEntity
    {
        public string Telephone { get; set; }

        public bool IsFax { get; set; }
        public bool IsPrimary { get; set; }

        public User User { get; set; }
        public int? UserId { get; set; }

        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }

        public SupplierEmployee SupplierPerson { get; set; }
        public int? SupplierPersonId { get; set; }

        public Supplier Supplier { get; set; }
        public int? SupplierId { get; set; }
    }
}