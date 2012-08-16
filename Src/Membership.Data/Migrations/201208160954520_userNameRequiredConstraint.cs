namespace Membership.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class userNameRequiredConstraint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Employees", "UserName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("SupplierEmployees", "UserName", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("SupplierEmployees", "UserName", c => c.String());
            AlterColumn("Employees", "UserName", c => c.String());
        }
    }
}
