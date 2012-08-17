
namespace Membership.Data
{
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using Membership.Data.Migrations;

    public class MigrationsInstaller
    {
        public static void Configure()
        {
            var configuration = new Configuration
            {
                AutomaticMigrationsEnabled = true,
                AutomaticMigrationDataLossAllowed = true,
                ContextType = typeof(MembershipDB),
                TargetDatabase = new DbConnectionInfo("MembershipDB")
            };

            var migratorScriptingDecorator = new MigratorScriptingDecorator(new DbMigrator(configuration));

            var pendingMigrations = migratorScriptingDecorator.GetPendingMigrations();
            var dbMigrator = new DbMigrator(configuration);

            foreach (var pendingMigration in pendingMigrations)
            {
                dbMigrator.Update(pendingMigration);                
            }
        }
    }
}
