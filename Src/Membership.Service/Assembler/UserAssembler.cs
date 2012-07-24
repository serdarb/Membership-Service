using System;
using Membership.Contract;
using Membership.Data;

namespace Membership.Service
{
    public class UserAssembler
    {
        public UserDto Assemble(User entity)
        {
            if (entity == null) { return null; }

            var userTypeAssembler = new UserTypeAssembler();
            var genderAssembler = new GenderAssembler();

            return new UserDto
                       {
                           Id = entity.Id,
                           Comment = entity.Comment,
                           LastUpdatedBy = entity.LastUpdatedBy,
                           CreatedOn = entity.CreatedOn,
                           UpdatedOn = entity.UpdatedOn,
                           DeletedOn = entity.DeletedOn.HasValue ? entity.DeletedOn.Value : new DateTime(),
                           UserType = userTypeAssembler.Assemble(entity.UserType),
                           Gender = genderAssembler.Assemble(entity.Gender),
                           Email = entity.Email,
                           PasswordHash = entity.PasswordHash,
                           Names = entity.Names,
                           FirstName = entity.FirstName,
                           LastName = entity.LastName,
                           PreferredName = entity.PreferredName,
                           IdentityNumber = entity.IdentityNumber,
                           Birthday = entity.Birthday,
                           Website = entity.Website,
                           FacebookId = entity.FacebookId,
                           TwitterId = entity.TwitterId,
                           PhotoUrl = entity.PhotoUrl,
                           IsActive = entity.IsActive,
                           IsMailingActive = entity.IsMailingActive,
                           IsOtherMailingActive = entity.IsOtherMailingActive,
                           AffiliateSlug = entity.AffiliateSlug,
                           RefererSource = entity.RefererSource,
                           LastInvoiceAddressId = entity.LastInvoiceAddressId,
                           LastShippingAddressId = entity.LastShippingAddressId,
                           Point = entity.Point,
                           VirtualMoney = entity.VirtualMoney
                       };
        }
    }
}