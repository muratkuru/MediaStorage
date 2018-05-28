namespace MediaStorage.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBaseEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.Materials", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.MaterialPropertyItems", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.MaterialTypeProperties", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.MaterialTypes", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.Stocks", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.Departments", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.Libraries", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.Lendings", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.Members", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.Reservations", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.Users", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.UserRoles", "IsRemoved");
            DropColumn("dbo.MenuItems", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.Menus", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
            DropColumn("dbo.Tags", "IsRemoved",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DefaultValueSql", "0" },
                });
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.Menus", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.MenuItems", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.UserRoles", "IsRemoved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.Reservations", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.Members", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.Lendings", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.Libraries", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.Departments", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.Stocks", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.MaterialTypes", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.MaterialTypeProperties", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.MaterialPropertyItems", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.Materials", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AddColumn("dbo.Categories", "IsRemoved", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValueSql",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
        }
    }
}
