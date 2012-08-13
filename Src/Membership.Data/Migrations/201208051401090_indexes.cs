namespace Membership.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class indexes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Users", "Email", true);
            CreateIndex("Employees", "Email", true);
            CreateIndex("SupplierEmployees", "Email", true);
        }

        public override void Down()
        {
            DropIndex("Users", "Email");
            DropIndex("Employees", "Email");
            DropIndex("SupplierEmployees", "Email");
        }
    }
}
