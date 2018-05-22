namespace MediaStorage.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class MajorUpdates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypeId)
                .ForeignKey("dbo.Categories", t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InternationalNumber = c.String(nullable: false, maxLength: 30),
                        Title = c.String(nullable: false),
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
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypeId)
                .Index(t => t.InternationalNumber, unique: true);
            
            CreateTable(
                "dbo.MaterialPropertyItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId)
                .ForeignKey("dbo.MaterialTypeProperties", t => t.MaterialTypePropertyId);
            
            CreateTable(
                "dbo.MaterialTypeProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MaterialTypeId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypeId);
            
            CreateTable(
                "dbo.MaterialTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Barcode = c.String(nullable: false),
                        Location = c.String(),
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
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
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
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Libraries", t => t.LibraryId);
            
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
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
                        UserId = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stocks", t => t.StockId)
                .ForeignKey("dbo.Users", t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Mail = c.String(nullable: false, maxLength: 200),
                        Address = c.String(),
                        PhoneNumber = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false),
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
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Mail, unique: true)
                .Index(t => t.PhoneNumber, unique: true);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationDate = c.DateTime(nullable: false),
                        StockId = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stocks", t => t.StockId)
                .ForeignKey("dbo.Users", t => t.UserId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
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
                        CreateDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        UpdatedDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "DefaultValueSql",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pages", t => t.ParentPageId);
            
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
            DropForeignKey("dbo.Pages", "ParentPageId", "dbo.Pages");
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryMaterials", "CategoryId", "dbo.Materials");
            DropForeignKey("dbo.CategoryMaterials", "MaterialId", "dbo.Categories");
            DropForeignKey("dbo.TagMaterials", "TagId", "dbo.Materials");
            DropForeignKey("dbo.TagMaterials", "MaterialId", "dbo.Tags");
            DropForeignKey("dbo.Stocks", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Reservations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reservations", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.Lendings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Lendings", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.Stocks", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Stocks", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Departments", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.MaterialTypeProperties", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.Categories", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.MaterialPropertyItems", "MaterialTypePropertyId", "dbo.MaterialTypeProperties");
            DropForeignKey("dbo.MaterialPropertyItems", "MaterialId", "dbo.Materials");
            DropIndex("dbo.Users", new[] { "PhoneNumber" });
            DropIndex("dbo.Users", new[] { "Mail" });
            DropIndex("dbo.Materials", new[] { "InternationalNumber" });
            DropTable("dbo.CategoryMaterials");
            DropTable("dbo.TagMaterials");
            DropTable("dbo.Pages",
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
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
                        }
                    },
                });
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
                    {
                        "IsRemoved",
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
                    {
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
                        }
                    },
                });
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
                    {
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
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
                    {
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
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
                    {
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
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
                    {
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
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
                    {
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
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
                    {
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
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
                    {
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
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
                    {
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
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
                    {
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
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
                    {
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
                        }
                    },
                });
            DropTable("dbo.Administrators",
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
                        "IsRemoved",
                        new Dictionary<string, object>
                        {
                            { "DefaultValueSql", "0" },
                        }
                    },
                });
        }
    }
}
