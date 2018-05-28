namespace MediaStorage.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ParentCategoryId = c.Int(),
                        MaterialTypeId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypeId)
                .ForeignKey("dbo.Categories", t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InternationalNumber = c.String(nullable: false, maxLength: 255),
                        Title = c.String(nullable: false, maxLength: 255),
                        PublishDate = c.DateTime(nullable: false),
                        Contents = c.String(),
                        ImageUrl = c.String(),
                        MaterialTypeId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypeId)
                .Index(t => t.InternationalNumber, unique: true);
            
            CreateTable(
                "dbo.MaterialPropertyItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        MaterialId = c.Int(nullable: false),
                        MaterialTypePropertyId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId)
                .ForeignKey("dbo.MaterialTypeProperties", t => t.MaterialTypePropertyId);
            
            CreateTable(
                "dbo.MaterialTypeProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        MaterialTypeId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypeId);
            
            CreateTable(
                "dbo.MaterialTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Barcode = c.String(nullable: false),
                        Location = c.String(nullable: false, maxLength: 255),
                        MaterialId = c.Int(nullable: false),
                        LibraryId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
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
                        Name = c.String(nullable: false, maxLength: 255),
                        LibraryId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Libraries", t => t.LibraryId);
            
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lendings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LendingDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        StockId = c.Int(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .ForeignKey("dbo.Stocks", t => t.StockId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 255),
                        Address = c.String(),
                        PhoneNumber = c.String(nullable: false, maxLength: 64),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.PhoneNumber, unique: true);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationDate = c.DateTime(nullable: false),
                        StockId = c.Int(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .ForeignKey("dbo.Stocks", t => t.StockId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Mail = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        IsActive = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Area = c.String(maxLength: 255),
                        Action = c.String(maxLength: 255),
                        Controller = c.String(maxLength: 255),
                        Icon = c.String(maxLength: 255),
                        RowIndex = c.Int(),
                        ParentMenuItemId = c.Int(),
                        MenuId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.MenuId)
                .ForeignKey("dbo.MenuItems", t => t.ParentMenuItemId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 255),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuItemUserRoles",
                c => new
                    {
                        MenuItemId = c.Int(nullable: false),
                        UserRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuItemId, t.UserRoleId })
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId);
            
            CreateTable(
                "dbo.UserUserRoles",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.UserRoleId })
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId);
            
            CreateTable(
                "dbo.TagMaterials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaterialId, t.TagId })
                .ForeignKey("dbo.Tags", t => t.MaterialId)
                .ForeignKey("dbo.Materials", t => t.TagId);
            
            CreateTable(
                "dbo.CategoryMaterials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaterialId, t.CategoryId })
                .ForeignKey("dbo.Categories", t => t.MaterialId)
                .ForeignKey("dbo.Materials", t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryMaterials", "CategoryId", "dbo.Materials");
            DropForeignKey("dbo.CategoryMaterials", "MaterialId", "dbo.Categories");
            DropForeignKey("dbo.TagMaterials", "TagId", "dbo.Materials");
            DropForeignKey("dbo.TagMaterials", "MaterialId", "dbo.Tags");
            DropForeignKey("dbo.Stocks", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Lendings", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.UserUserRoles", "UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.UserUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.MenuItemUserRoles", "UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.MenuItemUserRoles", "MenuItemId", "dbo.MenuItems");
            DropForeignKey("dbo.MenuItems", "ParentMenuItemId", "dbo.MenuItems");
            DropForeignKey("dbo.MenuItems", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.Members", "Id", "dbo.Users");
            DropForeignKey("dbo.Reservations", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.Reservations", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Lendings", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Stocks", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Stocks", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Departments", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.MaterialTypeProperties", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.Categories", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.MaterialPropertyItems", "MaterialTypePropertyId", "dbo.MaterialTypeProperties");
            DropForeignKey("dbo.MaterialPropertyItems", "MaterialId", "dbo.Materials");
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Members", new[] { "PhoneNumber" });
            DropIndex("dbo.Materials", new[] { "InternationalNumber" });
            DropTable("dbo.CategoryMaterials");
            DropTable("dbo.TagMaterials");
            DropTable("dbo.UserUserRoles");
            DropTable("dbo.MenuItemUserRoles");
            DropTable("dbo.Tags",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.Menus",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.MenuItems",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                    {
                        "IsActive",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
                        }
                    },
                });
            DropTable("dbo.Reservations",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.Members",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.Lendings",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.Libraries",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.Departments",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.Stocks",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.MaterialTypes",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.MaterialTypeProperties",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.MaterialPropertyItems",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.Materials",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.Categories",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreateDate",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "GETDATE()" },
                        }
                    },
                });
        }
    }
}
