using System.Runtime.Serialization;

namespace Membership.Contract
{
    [DataContract]
    public class SupplierDto : BaseDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ShortName { get; set; }
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public string LogoUrl { get; set; }

        [DataMember]
        public string TaxOffice { get; set; }
        [DataMember]
        public string TaxNumber { get; set; }

        [DataMember]
        public string PrimaryPersonName { get; set; }
        [DataMember]
        public string PrimaryPersonPhone { get; set; }
        [DataMember]
        public string PrimaryPersonGsm { get; set; }
        [DataMember]
        public string PrimaryPersonFax { get; set; }
        [DataMember]
        public string PrimaryPersonEmail { get; set; }

        [DataMember]
        public string PrimaryFinancialPersonName { get; set; }
        [DataMember]
        public string PrimaryFinancialPersonPhone { get; set; }
        [DataMember]
        public string PrimaryFinancialPersonGsm { get; set; }
        [DataMember]
        public string PrimaryFinancialPersonFax { get; set; }
        [DataMember]
        public string PrimaryFinancialPersonEmail { get; set; }
    }
}