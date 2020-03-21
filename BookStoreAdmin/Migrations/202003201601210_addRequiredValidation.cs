namespace BookStoreAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequiredValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sache", "TenSach", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sache", "TenSach", c => c.String(maxLength: 150));
        }
    }
}
