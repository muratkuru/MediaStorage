namespace MediaStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Materials", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.MaterialPropertyItems", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.MaterialTypeProperties", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.MaterialTypes", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Stocks", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Departments", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Libraries", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Lendings", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Members", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Reservations", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Users", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.UserRoles", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.MenuItems", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Menus", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Tags", "UpdateDate", c => c.DateTime());
            DropColumn("dbo.Categories", "UpdatedDate");
            DropColumn("dbo.Materials", "UpdatedDate");
            DropColumn("dbo.MaterialPropertyItems", "UpdatedDate");
            DropColumn("dbo.MaterialTypeProperties", "UpdatedDate");
            DropColumn("dbo.MaterialTypes", "UpdatedDate");
            DropColumn("dbo.Stocks", "UpdatedDate");
            DropColumn("dbo.Departments", "UpdatedDate");
            DropColumn("dbo.Libraries", "UpdatedDate");
            DropColumn("dbo.Lendings", "UpdatedDate");
            DropColumn("dbo.Members", "UpdatedDate");
            DropColumn("dbo.Reservations", "UpdatedDate");
            DropColumn("dbo.Users", "UpdatedDate");
            DropColumn("dbo.UserRoles", "UpdatedDate");
            DropColumn("dbo.MenuItems", "UpdatedDate");
            DropColumn("dbo.Menus", "UpdatedDate");
            DropColumn("dbo.Tags", "UpdatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Menus", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.MenuItems", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.UserRoles", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Users", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Reservations", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Members", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Lendings", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Libraries", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Departments", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Stocks", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.MaterialTypes", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.MaterialTypeProperties", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.MaterialPropertyItems", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Materials", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Categories", "UpdatedDate", c => c.DateTime());
            DropColumn("dbo.Tags", "UpdateDate");
            DropColumn("dbo.Menus", "UpdateDate");
            DropColumn("dbo.MenuItems", "UpdateDate");
            DropColumn("dbo.UserRoles", "UpdateDate");
            DropColumn("dbo.Users", "UpdateDate");
            DropColumn("dbo.Reservations", "UpdateDate");
            DropColumn("dbo.Members", "UpdateDate");
            DropColumn("dbo.Lendings", "UpdateDate");
            DropColumn("dbo.Libraries", "UpdateDate");
            DropColumn("dbo.Departments", "UpdateDate");
            DropColumn("dbo.Stocks", "UpdateDate");
            DropColumn("dbo.MaterialTypes", "UpdateDate");
            DropColumn("dbo.MaterialTypeProperties", "UpdateDate");
            DropColumn("dbo.MaterialPropertyItems", "UpdateDate");
            DropColumn("dbo.Materials", "UpdateDate");
            DropColumn("dbo.Categories", "UpdateDate");
        }
    }
}
