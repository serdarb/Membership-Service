namespace Membership.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class passwordResetFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("Employees", "PasswordResetRequestedOn", c => c.DateTime());
            AddColumn("Employees", "PasswordResetToken", c => c.String());
            AddColumn("SupplierEmployees", "PasswordResetRequestedOn", c => c.DateTime());
            AddColumn("SupplierEmployees", "PasswordResetToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("SupplierEmployees", "PasswordResetToken");
            DropColumn("SupplierEmployees", "PasswordResetRequestedOn");
            DropColumn("Employees", "PasswordResetToken");
            DropColumn("Employees", "PasswordResetRequestedOn");
        }
    }
}
