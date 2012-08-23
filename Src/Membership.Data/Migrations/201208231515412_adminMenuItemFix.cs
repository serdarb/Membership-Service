namespace Membership.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class adminMenuItemFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("AdminMenuItemGroups", "ParentAdminMenuItemGroupId", "AdminMenuItemGroups");
            DropForeignKey("AdminMenuItems", "AdminMenuItemGroupId", "AdminMenuItemGroups");
            DropIndex("AdminMenuItemGroups", new[] { "ParentAdminMenuItemGroupId" });
            DropIndex("AdminMenuItems", new[] { "AdminMenuItemGroupId" });
            AddColumn("AdminMenuItems", "ParentAdminMenuItemId", c => c.Int());
            AddForeignKey("AdminMenuItems", "ParentAdminMenuItemId", "AdminMenuItems", "Id");
            CreateIndex("AdminMenuItems", "ParentAdminMenuItemId");
            DropColumn("AdminMenuItems", "AdminMenuItemGroupId");
            DropTable("AdminMenuItemGroups");
        }
        
        public override void Down()
        {
            CreateTable(
                "AdminMenuItemGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentAdminMenuItemGroupId = c.Int(),
                        Name = c.String(),
                        Description = c.String(),
                        NavigateUrl = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("AdminMenuItems", "AdminMenuItemGroupId", c => c.Int());
            DropIndex("AdminMenuItems", new[] { "ParentAdminMenuItemId" });
            DropForeignKey("AdminMenuItems", "ParentAdminMenuItemId", "AdminMenuItems");
            DropColumn("AdminMenuItems", "ParentAdminMenuItemId");
            CreateIndex("AdminMenuItems", "AdminMenuItemGroupId");
            CreateIndex("AdminMenuItemGroups", "ParentAdminMenuItemGroupId");
            AddForeignKey("AdminMenuItems", "AdminMenuItemGroupId", "AdminMenuItemGroups", "Id");
            AddForeignKey("AdminMenuItemGroups", "ParentAdminMenuItemGroupId", "AdminMenuItemGroups", "Id");
        }
    }
}
