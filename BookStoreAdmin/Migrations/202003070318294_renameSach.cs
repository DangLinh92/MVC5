namespace BookStoreAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameSach : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Sach", newName: "Sache");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Sache", newName: "Sach");
        }
    }
}
