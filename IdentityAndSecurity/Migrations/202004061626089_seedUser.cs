namespace IdentityAndSecurity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUser : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cfa9ec15-0c43-4761-ad4c-a97849713309', N'hoamoclan.3192@gmail.com', 0, N'AIkvSD86Z7riCFsGboJ8FP2oj+d/5Q/rFAUP4GhKYSwCSTOA4mh1aeXakYwWxxy9kw==', N'70f06eaf-c8c3-4640-9b0d-ce3847775fc4', NULL, 0, 0, NULL, 1, 0, N'hoamoclan.3192@gmail.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'721ad2eb-2d4c-44e1-8c5c-45dbedf6f1f8', N'Develop')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cfa9ec15-0c43-4761-ad4c-a97849713309', N'721ad2eb-2d4c-44e1-8c5c-45dbedf6f1f8')"
);
        }
        
        public override void Down()
        {
        }
    }
}
