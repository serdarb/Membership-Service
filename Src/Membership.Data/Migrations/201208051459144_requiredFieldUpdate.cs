namespace Membership.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class requiredFieldUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("UserTypes", "Name", c => c.String(nullable: false));
            AlterColumn("Genders", "Name", c => c.String(nullable: false));
            AlterColumn("Counties", "Name", c => c.String(nullable: false));
            AlterColumn("Cities", "Name", c => c.String(nullable: false));
            AlterColumn("GeoZones", "Name", c => c.String(nullable: false));
            AlterColumn("Countries", "Name", c => c.String(nullable: false));
            AlterColumn("Countries", "ShortName", c => c.String(nullable: false));
            AlterColumn("Countries", "CountryCode", c => c.String(nullable: false));
            AlterColumn("AdminRoles", "Name", c => c.String(nullable: false));
            AlterColumn("LogEvents", "Name", c => c.String(nullable: false));
            AlterColumn("PointTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("PointTypes", "Name", c => c.String());
            AlterColumn("LogEvents", "Name", c => c.String());
            AlterColumn("AdminRoles", "Name", c => c.String());
            AlterColumn("Countries", "CountryCode", c => c.String());
            AlterColumn("Countries", "ShortName", c => c.String());
            AlterColumn("Countries", "Name", c => c.String());
            AlterColumn("GeoZones", "Name", c => c.String());
            AlterColumn("Cities", "Name", c => c.String());
            AlterColumn("Counties", "Name", c => c.String());
            AlterColumn("Genders", "Name", c => c.String());
            AlterColumn("UserTypes", "Name", c => c.String());
        }
    }
}
