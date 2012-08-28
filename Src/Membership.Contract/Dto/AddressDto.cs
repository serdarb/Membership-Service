namespace Membership.Contract
{
    using System.Runtime.Serialization;

    [DataContract]
    public class AddressDto : BaseDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string AddressText { get; set; }

        [DataMember]
        public string AddressType { get; set; }

        [DataMember]
        public string District { get; set; }

        [DataMember]
        public CountyDto County { get; set; }

        [DataMember]
        public CityDto City { get; set; }

        [DataMember]
        public GeoZoneDto GeoZone { get; set; }

        [DataMember]
        public CountryDto Country { get; set; }

        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Coordinates { get; set; }

        [DataMember]
        public string PersonName { get; set; }
        [DataMember]
        public string PrimaryPhone { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string TaxNumber { get; set; }
        [DataMember]
        public string TaxOffice { get; set; }

        [DataMember]
        public bool IsApproved { get; set; }
        [DataMember]
        public bool IsCompany { get; set; }

        [DataMember]
        public UserDto User { get; set; }
        [DataMember]
        public SupplierDto Supplier { get; set; }
        [DataMember]
        public SupplierEmployeeDto SupplierEmployee { get; set; }
        [DataMember]
        public EmployeeDto Employee { get; set; }

    }
}