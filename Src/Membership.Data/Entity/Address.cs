namespace Membership.Data.Entity
{
    using System;

    [Serializable]
    public class Address : BaseEntity
    {
        public string Name { get; set; }
        public string AddressText { get; set; }

        public string AddressType { get; set; }

        public string District { get; set; }

        public County County { get; set; }
        public int? CountyId { get; set; }

        public City City { get; set; }
        public int? CityId { get; set; }

        public GeoZone GeoZone { get; set; }
        public int? GeoZoneId { get; set; }

        public Country Country { get; set; }
        public int? CountryId { get; set; }

        public string PostalCode { get; set; }

        public string Coordinates { get; set; }

        public string PersonName { get; set; }
        public string PrimaryPhone { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }

        public bool IsApproved { get; set; }
        public bool IsCompany { get; set; }
        
        public User User { get; set; }
        public int? UserId { get; set; }
        
        public Supplier Supplier { get; set; }
        public int? SupplierId { get; set; }
        
        public SupplierEmployee SupplierEmployee { get; set; }
        public int? SupplierEmployeeId { get; set; }

        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }
    }
}