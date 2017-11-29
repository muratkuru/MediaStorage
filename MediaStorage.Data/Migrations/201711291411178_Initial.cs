namespace MediaStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Borrowings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcceptanceDate = c.DateTime(nullable: false),
                        FinalDeliveryDate = c.DateTime(nullable: false),
                        StockId = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stocks", t => t.StockId)
                .ForeignKey("dbo.Users", t => t.UserId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FixtureNumber = c.String(nullable: false),
                        Location = c.String(),
                        MaterialId = c.String(nullable: false, maxLength: 128),
                        LibraryId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Libraries", t => t.LibraryId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Materials", t => t.MaterialId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LibraryId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Libraries", t => t.LibraryId);
            
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        Contents = c.String(),
                        ImageUrl = c.String(),
                        MaterialTypeId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypeId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentCategoryId = c.Int(),
                        MaterialTypeId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypeId)
                .ForeignKey("dbo.Categories", t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.MaterialTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaterialProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MaterialTypeId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypeId);
            
            CreateTable(
                "dbo.MaterialPropertyItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MaterialId = c.String(nullable: false, maxLength: 128),
                        MaterialPropertyId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId)
                .ForeignKey("dbo.MaterialProperties", t => t.MaterialPropertyId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationDate = c.DateTime(nullable: false),
                        StockId = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stocks", t => t.StockId)
                .ForeignKey("dbo.Users", t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Area = c.String(),
                        Action = c.String(),
                        Controller = c.String(),
                        Icon = c.String(),
                        ParentPageId = c.Int(),
                        RowIndex = c.Int(),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pages", t => t.ParentPageId);
            
            CreateTable(
                "dbo.CategoryMaterials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false),
                        CategoryId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MaterialId, t.CategoryId })
                .ForeignKey("dbo.Categories", t => t.MaterialId)
                .ForeignKey("dbo.Materials", t => t.CategoryId);
            
            CreateTable(
                "dbo.TagMaterials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false),
                        TagId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MaterialId, t.TagId })
                .ForeignKey("dbo.Tags", t => t.MaterialId)
                .ForeignKey("dbo.Materials", t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "ParentPageId", "dbo.Pages");
            DropForeignKey("dbo.Reservations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Borrowings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reservations", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.TagMaterials", "TagId", "dbo.Materials");
            DropForeignKey("dbo.TagMaterials", "MaterialId", "dbo.Tags");
            DropForeignKey("dbo.Stocks", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.MaterialProperties", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.MaterialPropertyItems", "MaterialPropertyId", "dbo.MaterialProperties");
            DropForeignKey("dbo.MaterialPropertyItems", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Categories", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.CategoryMaterials", "CategoryId", "dbo.Materials");
            DropForeignKey("dbo.CategoryMaterials", "MaterialId", "dbo.Categories");
            DropForeignKey("dbo.Stocks", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Stocks", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Departments", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Borrowings", "StockId", "dbo.Stocks");
            DropTable("dbo.TagMaterials");
            DropTable("dbo.CategoryMaterials");
            DropTable("dbo.Pages");
            DropTable("dbo.Users");
            DropTable("dbo.Reservations");
            DropTable("dbo.Tags");
            DropTable("dbo.MaterialPropertyItems");
            DropTable("dbo.MaterialProperties");
            DropTable("dbo.MaterialTypes");
            DropTable("dbo.Categories");
            DropTable("dbo.Materials");
            DropTable("dbo.Libraries");
            DropTable("dbo.Departments");
            DropTable("dbo.Stocks");
            DropTable("dbo.Borrowings");
        }
    }
}
