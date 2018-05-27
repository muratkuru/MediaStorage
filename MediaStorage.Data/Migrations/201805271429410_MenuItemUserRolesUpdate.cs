namespace MediaStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuItemUserRolesUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MenuItemUserRoles", name: "UserRoleId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.MenuItemUserRoles", name: "MenuItemId", newName: "UserRoleId");
            RenameColumn(table: "dbo.MenuItemUserRoles", name: "__mig_tmp__0", newName: "MenuItemId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.MenuItemUserRoles", name: "MenuItemId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.MenuItemUserRoles", name: "UserRoleId", newName: "MenuItemId");
            RenameColumn(table: "dbo.MenuItemUserRoles", name: "__mig_tmp__0", newName: "UserRoleId");
        }
    }
}
