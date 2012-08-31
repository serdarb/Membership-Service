namespace Membership.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class addressGeoZoneFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Addresses", "GeoZoneId", "GeoZones");
            DropForeignKey("Addresses", "CountryId", "Countries");
            DropIndex("Addresses", new[] { "GeoZoneId" });
            DropIndex("Addresses", new[] { "CountryId" });
            DropColumn("Addresses", "GeoZoneId");
            DropColumn("Addresses", "CountryId");
        }
        
        public override void Down()
        {
            AddColumn("Addresses", "CountryId", c => c.Int());
            AddColumn("Addresses", "GeoZoneId", c => c.Int());
            CreateIndex("Addresses", "CountryId");
            CreateIndex("Addresses", "GeoZoneId");
            AddForeignKey("Addresses", "CountryId", "Countries", "Id");
            AddForeignKey("Addresses", "GeoZoneId", "GeoZones", "Id");
        }
    }
}
