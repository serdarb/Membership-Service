namespace Membership.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class activatedOnMadeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Affiliates", "ActivatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("Affiliates", "ActivatedOn", c => c.DateTime(nullable: false));
        }
    }
}
