using System;
using Membership.Contract;
using Membership.Data;

namespace Membership.Service
{
    class GenderAssembler
    {
        public GenderDto Assemble(Gender entity)
        {
            if (entity == null) { return null; }
            return new GenderDto
                       {
                           Id = entity.Id,
                           Comment = entity.Comment,
                           LastUpdatedBy = entity.LastUpdatedBy,
                           CreatedOn = entity.CreatedOn,
                           UpdatedOn = entity.UpdatedOn,
                           DeletedOn = entity.DeletedOn.HasValue ? entity.DeletedOn.Value : new DateTime(),
                           Name = entity.Name,
                           Description = entity.Description
                       };
        }
    }
}