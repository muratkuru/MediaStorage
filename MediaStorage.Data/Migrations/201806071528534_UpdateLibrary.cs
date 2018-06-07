namespace MediaStorage.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLibrary : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stocks", "LibraryId", "dbo.Libraries");
            DropColumn("dbo.Stocks", "LibraryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "LibraryId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Stocks", "LibraryId", "dbo.Libraries", "Id");
        }
    }
}
