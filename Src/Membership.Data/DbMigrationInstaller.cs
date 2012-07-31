using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using Membership.Data.Migrations;

namespace Membership.Data
{
    public static class DbMigrationInstaller 
    {
        public static void Configure()
        {
            var configuration = new Configuration
                                    {
                                        AutomaticMigrationsEnabled = true,
                                        ContextType = typeof(MembershipDB),
                                        AutomaticMigrationDataLossAllowed = true,
                                        //TargetDatabase = new DbConnectionInfo("Data Source=|DataDirectory|myblogdb.sdf", "System.Data.SqlServerCe.4.0"),  connection defines
                                        TargetDatabase = new DbConnectionInfo(@"Data Source=.\SQLEXPRESS; Integrated Security=True; MultipleActiveResultSets=True", "System.Data.SqlClient"),  

                                    };
             
            var migratorScriptingDecorator = new MigratorScriptingDecorator(new DbMigrator(configuration));
             
            IEnumerable<string> pendingMigrations = migratorScriptingDecorator.GetPendingMigrations();

            var dbMigrator = new DbMigrator(configuration);

            foreach (var pendingMigration in pendingMigrations)
            {
                dbMigrator.Update(pendingMigration);    
            }

        

        }
    }
}
