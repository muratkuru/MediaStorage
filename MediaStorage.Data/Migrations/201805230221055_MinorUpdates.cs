namespace MediaStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorUpdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Administrators", "Username", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Administrators", "Mail", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Administrators", "Password", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Materials", "Title", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("dbo.MaterialTypeProperties", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.MaterialTypes", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Libraries", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "FullName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.Administrators", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Administrators", new[] { "Username" });
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FullName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Libraries", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MaterialTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.MaterialTypeProperties", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Materials", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Administrators", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Administrators", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Administrators", "Username", c => c.String(nullable: false));
        }
    }
}
