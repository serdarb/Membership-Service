using System.Data.Entity;

namespace Membership.Data
{
    internal class MembershipDBDatabaseInitializer : CreateDatabaseIfNotExists<MembershipDB>
    {
        protected override void Seed(MembershipDB context)
        {
            MetaInit.InsertGender(context);
            MetaInit.InsertUserType(context);
            MetaInit.InsertLogEvent(context);
            MetaInit.InsertMenuItems(context);
            MetaInit.InsertRole(context);
            MetaInit.InsertCountryTurkeyAndGeoZones(context);
            MetaInit.InsertCity(context);
            MetaInit.InsertCounty(context);
            MetaInit.InsertUsers(context);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}