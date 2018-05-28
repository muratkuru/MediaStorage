namespace MediaStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUserRole : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserUserRoles", name: "UserRoleId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.UserUserRoles", name: "UserId", newName: "UserRoleId");
            RenameColumn(table: "dbo.UserUserRoles", name: "__mig_tmp__0", newName: "UserId");
            DropPrimaryKey("dbo.UserUserRoles");
            AlterColumn("dbo.UserUserRoles", "UserRoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserUserRoles", "UserId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.UserUserRoles", new[] { "UserId", "UserRoleId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserUserRoles");
            AlterColumn("dbo.UserUserRoles", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserUserRoles", "UserRoleId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.UserUserRoles", new[] { "UserRoleId", "UserId" });
            RenameColumn(table: "dbo.UserUserRoles", name: "UserId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.UserUserRoles", name: "UserRoleId", newName: "UserId");
            RenameColumn(table: "dbo.UserUserRoles", name: "__mig_tmp__0", newName: "UserRoleId");
        }
    }
}
