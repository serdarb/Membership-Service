namespace Membership.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class addressTypeUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("Addresses", "AddressType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Addresses", "AddressType");
        }
    }
}
