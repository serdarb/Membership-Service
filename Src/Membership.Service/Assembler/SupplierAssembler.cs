using System;
using Membership.Contract;
using Membership.Data;

namespace Membership.Service
{
    public class SupplierAssembler
    {
        public SupplierDto Assemble(Supplier entity)
        {
            if (entity == null) { return null; }
            return new SupplierDto
                       {
                           Id = entity.Id,
                           Comment = entity.Comment,
                           LastUpdatedBy = entity.LastUpdatedBy,
                           CreatedOn = entity.CreatedOn,
                           UpdatedOn = entity.UpdatedOn,
                           DeletedOn = entity.DeletedOn.HasValue ? entity.DeletedOn.Value : new DateTime(),
                           Name = entity.Name,
                           Description = entity.Description,
                           LogoUrl = entity.LogoUrl,
                           PrimaryPersonEmail = entity.PrimaryPersonEmail,
                           PrimaryPersonFax = entity.PrimaryPersonFax,
                           PrimaryPersonGsm = entity.PrimaryPersonGsm,
                           PrimaryPersonName = entity.PrimaryPersonName,
                           PrimaryPersonPhone = entity.PrimaryPersonPhone,
                           PrimaryFinancialPersonEmail = entity.PrimaryFinancialPersonEmail,
                           PrimaryFinancialPersonFax = entity.PrimaryFinancialPersonFax,
                           PrimaryFinancialPersonGsm = entity.PrimaryFinancialPersonGsm,
                           PrimaryFinancialPersonName = entity.PrimaryFinancialPersonName,
                           PrimaryFinancialPersonPhone = entity.PrimaryFinancialPersonPhone,
                           ShortName = entity.ShortName,
                           TaxNumber = entity.TaxNumber,
                           TaxOffice = entity.TaxOffice,
                           Website = entity.Website
                       };
        }

    }
}