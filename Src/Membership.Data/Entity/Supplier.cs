namespace Membership.Data.Entity
{
    using System;

    [Serializable]
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }

        public string Website { get; set; }
        public string LogoUrl { get; set; }

        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }

        public string PrimaryPersonName { get; set; }
        public string PrimaryPersonPhone { get; set; }
        public string PrimaryPersonGsm { get; set; }
        public string PrimaryPersonFax { get; set; }
        public string PrimaryPersonEmail { get; set; }

        public string PrimaryFinancialPersonName { get; set; }
        public string PrimaryFinancialPersonPhone { get; set; }
        public string PrimaryFinancialPersonGsm { get; set; }
        public string PrimaryFinancialPersonFax { get; set; }
        public string PrimaryFinancialPersonEmail { get; set; }
    }
}