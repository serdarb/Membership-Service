namespace Membership.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class employeeAddressFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("Addresses", "EmployeeId", c => c.Int());
            AddForeignKey("Addresses", "EmployeeId", "Employees", "Id");
            CreateIndex("Addresses", "EmployeeId");
        }
        
        public override void Down()
        {
            DropIndex("Addresses", new[] { "EmployeeId" });
            DropForeignKey("Addresses", "EmployeeId", "Employees");
            DropColumn("Addresses", "EmployeeId");
        }
    }
}
