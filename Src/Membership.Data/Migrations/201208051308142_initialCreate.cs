namespace Membership.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 255),
                        PasswordHash = c.String(nullable: false),
                        Names = c.String(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PreferredName = c.String(),
                        IdentityNumber = c.String(),
                        Birthday = c.DateTime(),
                        Website = c.String(),
                        FacebookId = c.String(),
                        TwitterId = c.String(),
                        PinterestId = c.String(),
                        SkypeId = c.String(),
                        PhotoUrl = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsMailingActive = c.Boolean(nullable: false),
                        IsOtherMailingActive = c.Boolean(nullable: false),
                        VirtualMoney = c.Int(nullable: false),
                        Point = c.Int(nullable: false),
                        AffiliateSlug = c.String(),
                        RefererSource = c.String(),
                        LastInvoiceAddressId = c.String(),
                        LastShippingAddressId = c.String(),
                        UserTypeId = c.Int(),
                        GenderId = c.Int(),
                        PasswordResetRequestedOn = c.DateTime(),
                        PasswordResetToken = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("UserTypes", t => t.UserTypeId)
                .ForeignKey("Genders", t => t.GenderId)
                .Index(t => t.UserTypeId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Telephone = c.String(),
                        IsFax = c.Boolean(nullable: false),
                        IsPrimary = c.Boolean(nullable: false),
                        UserId = c.Int(),
                        EmployeeId = c.Int(),
                        SupplierPersonId = c.Int(),
                        SupplierId = c.Int(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users", t => t.UserId)
                .ForeignKey("Employees", t => t.EmployeeId)
                .ForeignKey("SupplierEmployees", t => t.SupplierPersonId)
                .ForeignKey("Suppliers", t => t.SupplierId)
                .Index(t => t.UserId)
                .Index(t => t.EmployeeId)
                .Index(t => t.SupplierPersonId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        Email = c.String(nullable: false, maxLength: 255),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        PrimaryPhone = c.String(),
                        Department = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "SupplierEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        SupplierId = c.Int(),
                        Email = c.String(nullable: false, maxLength: 255),
                        PrimaryPhone = c.String(),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        Department = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users", t => t.UserId)
                .ForeignKey("Suppliers", t => t.SupplierId)
                .Index(t => t.UserId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Description = c.String(),
                        Website = c.String(),
                        LogoUrl = c.String(),
                        TaxOffice = c.String(),
                        TaxNumber = c.String(),
                        PrimaryPersonName = c.String(),
                        PrimaryPersonPhone = c.String(),
                        PrimaryPersonGsm = c.String(),
                        PrimaryPersonFax = c.String(),
                        PrimaryPersonEmail = c.String(),
                        PrimaryFinancialPersonName = c.String(),
                        PrimaryFinancialPersonPhone = c.String(),
                        PrimaryFinancialPersonGsm = c.String(),
                        PrimaryFinancialPersonFax = c.String(),
                        PrimaryFinancialPersonEmail = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressText = c.String(),
                        District = c.String(),
                        CountyId = c.Int(),
                        CityId = c.Int(),
                        GeoZoneId = c.Int(),
                        CountryId = c.Int(),
                        PostalCode = c.String(),
                        Coordinates = c.String(),
                        PersonName = c.String(),
                        PrimaryPhone = c.String(),
                        CompanyName = c.String(),
                        TaxNumber = c.String(),
                        TaxOffice = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        IsCompany = c.Boolean(nullable: false),
                        UserId = c.Int(),
                        SupplierId = c.Int(),
                        SupplierEmployeeId = c.Int(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Counties", t => t.CountyId)
                .ForeignKey("Cities", t => t.CityId)
                .ForeignKey("GeoZones", t => t.GeoZoneId)
                .ForeignKey("Countries", t => t.CountryId)
                .ForeignKey("Users", t => t.UserId)
                .ForeignKey("Suppliers", t => t.SupplierId)
                .ForeignKey("SupplierEmployees", t => t.SupplierEmployeeId)
                .Index(t => t.CountyId)
                .Index(t => t.CityId)
                .Index(t => t.GeoZoneId)
                .Index(t => t.CountryId)
                .Index(t => t.UserId)
                .Index(t => t.SupplierId)
                .Index(t => t.SupplierEmployeeId);
            
            CreateTable(
                "Counties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GeoZoneId = c.Int(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("GeoZones", t => t.GeoZoneId)
                .Index(t => t.GeoZoneId);
            
            CreateTable(
                "GeoZones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        CountryCode = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Affiliates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 255),
                        UserId = c.Int(),
                        RefererSource = c.String(),
                        ActivatedOn = c.DateTime(nullable: false),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users", t => t.UserId)
                .Index(t => t.UserId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("AdminMenuItemGroups", t => t.ParentAdminMenuItemGroupId)
                .Index(t => t.ParentAdminMenuItemGroupId);
            
            CreateTable(
                "AdminMenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminMenuItemGroupId = c.Int(),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("AdminMenuItemGroups", t => t.AdminMenuItemGroupId)
                .Index(t => t.AdminMenuItemGroupId);
            
            CreateTable(
                "AdminMenuItemRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminMenuItemId = c.Int(),
                        AdminRoleId = c.Int(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("AdminMenuItems", t => t.AdminMenuItemId)
                .ForeignKey("AdminRoles", t => t.AdminRoleId)
                .Index(t => t.AdminMenuItemId)
                .Index(t => t.AdminRoleId);
            
            CreateTable(
                "AdminRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "EmployeeAdminRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(),
                        AdminRoleId = c.Int(),
                        Expression = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Employees", t => t.EmployeeId)
                .ForeignKey("AdminRoles", t => t.AdminRoleId)
                .Index(t => t.EmployeeId)
                .Index(t => t.AdminRoleId);
            
            CreateTable(
                "SupplierEmployeeAdminRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierEmployeeId = c.Int(),
                        AdminRoleId = c.Int(),
                        Expression = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SupplierEmployees", t => t.SupplierEmployeeId)
                .ForeignKey("AdminRoles", t => t.AdminRoleId)
                .Index(t => t.SupplierEmployeeId)
                .Index(t => t.AdminRoleId);
            
            CreateTable(
                "Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogEventId = c.Int(),
                        Expression = c.String(),
                        OldRow = c.String(),
                        NewRow = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("LogEvents", t => t.LogEventId)
                .Index(t => t.LogEventId);
            
            CreateTable(
                "LogEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PointTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Point = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PointHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        PointTypeId = c.Int(),
                        Point = c.Int(nullable: false),
                        Expression = c.String(),
                        Comment = c.String(),
                        UpdatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users", t => t.UserId)
                .ForeignKey("PointTypes", t => t.PointTypeId)
                .Index(t => t.UserId)
                .Index(t => t.PointTypeId);
            
        }
        
        public override void Down()
        {
            DropIndex("PointHistories", new[] { "PointTypeId" });
            DropIndex("PointHistories", new[] { "UserId" });
            DropIndex("Logs", new[] { "LogEventId" });
            DropIndex("SupplierEmployeeAdminRoles", new[] { "AdminRoleId" });
            DropIndex("SupplierEmployeeAdminRoles", new[] { "SupplierEmployeeId" });
            DropIndex("EmployeeAdminRoles", new[] { "AdminRoleId" });
            DropIndex("EmployeeAdminRoles", new[] { "EmployeeId" });
            DropIndex("AdminMenuItemRoles", new[] { "AdminRoleId" });
            DropIndex("AdminMenuItemRoles", new[] { "AdminMenuItemId" });
            DropIndex("AdminMenuItems", new[] { "AdminMenuItemGroupId" });
            DropIndex("AdminMenuItemGroups", new[] { "ParentAdminMenuItemGroupId" });
            DropIndex("Affiliates", new[] { "UserId" });
            DropIndex("GeoZones", new[] { "CountryId" });
            DropIndex("Cities", new[] { "GeoZoneId" });
            DropIndex("Counties", new[] { "CityId" });
            DropIndex("Addresses", new[] { "SupplierEmployeeId" });
            DropIndex("Addresses", new[] { "SupplierId" });
            DropIndex("Addresses", new[] { "UserId" });
            DropIndex("Addresses", new[] { "CountryId" });
            DropIndex("Addresses", new[] { "GeoZoneId" });
            DropIndex("Addresses", new[] { "CityId" });
            DropIndex("Addresses", new[] { "CountyId" });
            DropIndex("SupplierEmployees", new[] { "SupplierId" });
            DropIndex("SupplierEmployees", new[] { "UserId" });
            DropIndex("Employees", new[] { "UserId" });
            DropIndex("Phones", new[] { "SupplierId" });
            DropIndex("Phones", new[] { "SupplierPersonId" });
            DropIndex("Phones", new[] { "EmployeeId" });
            DropIndex("Phones", new[] { "UserId" });
            DropIndex("Users", new[] { "GenderId" });
            DropIndex("Users", new[] { "UserTypeId" });
            DropForeignKey("PointHistories", "PointTypeId", "PointTypes");
            DropForeignKey("PointHistories", "UserId", "Users");
            DropForeignKey("Logs", "LogEventId", "LogEvents");
            DropForeignKey("SupplierEmployeeAdminRoles", "AdminRoleId", "AdminRoles");
            DropForeignKey("SupplierEmployeeAdminRoles", "SupplierEmployeeId", "SupplierEmployees");
            DropForeignKey("EmployeeAdminRoles", "AdminRoleId", "AdminRoles");
            DropForeignKey("EmployeeAdminRoles", "EmployeeId", "Employees");
            DropForeignKey("AdminMenuItemRoles", "AdminRoleId", "AdminRoles");
            DropForeignKey("AdminMenuItemRoles", "AdminMenuItemId", "AdminMenuItems");
            DropForeignKey("AdminMenuItems", "AdminMenuItemGroupId", "AdminMenuItemGroups");
            DropForeignKey("AdminMenuItemGroups", "ParentAdminMenuItemGroupId", "AdminMenuItemGroups");
            DropForeignKey("Affiliates", "UserId", "Users");
            DropForeignKey("GeoZones", "CountryId", "Countries");
            DropForeignKey("Cities", "GeoZoneId", "GeoZones");
            DropForeignKey("Counties", "CityId", "Cities");
            DropForeignKey("Addresses", "SupplierEmployeeId", "SupplierEmployees");
            DropForeignKey("Addresses", "SupplierId", "Suppliers");
            DropForeignKey("Addresses", "UserId", "Users");
            DropForeignKey("Addresses", "CountryId", "Countries");
            DropForeignKey("Addresses", "GeoZoneId", "GeoZones");
            DropForeignKey("Addresses", "CityId", "Cities");
            DropForeignKey("Addresses", "CountyId", "Counties");
            DropForeignKey("SupplierEmployees", "SupplierId", "Suppliers");
            DropForeignKey("SupplierEmployees", "UserId", "Users");
            DropForeignKey("Employees", "UserId", "Users");
            DropForeignKey("Phones", "SupplierId", "Suppliers");
            DropForeignKey("Phones", "SupplierPersonId", "SupplierEmployees");
            DropForeignKey("Phones", "EmployeeId", "Employees");
            DropForeignKey("Phones", "UserId", "Users");
            DropForeignKey("Users", "GenderId", "Genders");
            DropForeignKey("Users", "UserTypeId", "UserTypes");
            DropTable("PointHistories");
            DropTable("PointTypes");
            DropTable("LogEvents");
            DropTable("Logs");
            DropTable("SupplierEmployeeAdminRoles");
            DropTable("EmployeeAdminRoles");
            DropTable("AdminRoles");
            DropTable("AdminMenuItemRoles");
            DropTable("AdminMenuItems");
            DropTable("AdminMenuItemGroups");
            DropTable("Affiliates");
            DropTable("Countries");
            DropTable("GeoZones");
            DropTable("Cities");
            DropTable("Counties");
            DropTable("Addresses");
            DropTable("Suppliers");
            DropTable("SupplierEmployees");
            DropTable("Employees");
            DropTable("Phones");
            DropTable("Genders");
            DropTable("UserTypes");
            DropTable("Users");
        }
    }
}
