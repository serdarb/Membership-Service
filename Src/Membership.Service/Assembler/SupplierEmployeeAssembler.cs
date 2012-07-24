using System;
using Membership.Contract;
using Membership.Data;

namespace Membership.Service
{
    public class SupplierEmployeeAssembler
    {
        public SupplierEmployeeDto Assemble(SupplierEmployee entity)
        {
            if (entity == null) { return null; }
            var userAssembler = new UserAssembler();
            var supplierAssembler = new SupplierAssembler();
            return new SupplierEmployeeDto
                       {
                           Id = entity.Id,
                           Comment = entity.Comment,
                           LastUpdatedBy = entity.LastUpdatedBy,
                           CreatedOn = entity.CreatedOn,
                           UpdatedOn = entity.UpdatedOn,
                           DeletedOn = entity.DeletedOn.HasValue ? entity.DeletedOn.Value : new DateTime(),
                           User = userAssembler.Assemble(entity.User),
                           Supplier = supplierAssembler.Assemble(entity.Supplier),
                           Email = entity.Email,
                           UserName = entity.UserName,
                           PasswordHash = entity.PasswordHash,
                           Department = entity.Department,
                           PrimaryPhone = entity.PrimaryPhone,
                
                       };
        }
    }
}