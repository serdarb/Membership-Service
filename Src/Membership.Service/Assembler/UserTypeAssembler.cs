using System;
using Membership.Contract;
using Membership.Data;

namespace Membership.Service
{
    public class UserTypeAssembler
    {
        public UserTypeDto Assemble(UserType entity)
        {
            if (entity == null) { return null; }
            return new UserTypeDto
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