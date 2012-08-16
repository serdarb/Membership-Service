namespace Membership.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class userNameIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Employees", "UserName", true);
            CreateIndex("SupplierEmployees", "UserName", true);
        }
        
        public override void Down()
        {
            DropIndex("Employees", "UserName");
            DropIndex("SupplierEmployees", "UserName");
        }
    }
}
