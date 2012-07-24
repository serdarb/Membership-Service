using System;
using Membership.Contract;
using Membership.Data;

namespace Membership.Service
{
    public class EmployeeAssembler
    {
        public EmployeeDto Assemble(Employee entity)
        {
            if (entity == null) { return null; }
            var userAssembler = new UserAssembler();
            return new EmployeeDto
            {
                Id = entity.Id,
                Comment = entity.Comment,
                LastUpdatedBy = entity.LastUpdatedBy,
                CreatedOn = entity.CreatedOn,
                UpdatedOn = entity.UpdatedOn,
                DeletedOn = entity.DeletedOn.HasValue ? entity.DeletedOn.Value : new DateTime(),
                User = userAssembler.Assemble(entity.User),
                Email = entity.Email,
                UserName = entity.UserName,
                PasswordHash = entity.PasswordHash,
                Department = entity.Department,
                PrimaryPhone = entity.PrimaryPhone
            };
        }
    }
}