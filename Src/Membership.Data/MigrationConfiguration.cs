using System.Data.Entity.Migrations;

namespace Membership.Data
{
    internal sealed class MigrationConfiguration : DbMigrationsConfiguration<MembershipDB>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}