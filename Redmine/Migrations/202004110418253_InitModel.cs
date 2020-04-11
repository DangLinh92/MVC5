namespace Redmine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Issue",
                c => new
                    {
                        IssueId = c.String(nullable: false, maxLength: 50),
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.String(nullable: false, maxLength: 128),
                        TrackerId = c.String(nullable: false, maxLength: 128),
                        StatusId = c.String(nullable: false, maxLength: 128),
                        PriorityId = c.String(nullable: false, maxLength: 128),
                        CategoryId = c.String(nullable: false, maxLength: 128),
                        ParentTaskId = c.String(nullable: false),
                        DetectedProcessId = c.String(nullable: false, maxLength: 128),
                        RootCausalProcessId = c.String(nullable: false, maxLength: 128),
                        RelatedIssue = c.String(),
                        Subject = c.String(maxLength: 250),
                        DueDate = c.DateTime(),
                        PercentDone = c.Int(),
                        EstimateTime = c.Double(),
                        SpendTime = c.Double(),
                        StartDate = c.DateTime(),
                        UpdateTime = c.DateTime(),
                        Description = c.String(),
                        FunctionPoint = c.Double(nullable: false),
                        Remark = c.String(),
                        IsDeleted = c.Int(),
                        ParentIssue_IssueId = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IssueId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.DetectedProcesses", t => t.DetectedProcessId)
                .ForeignKey("dbo.Issue", t => t.ParentIssue_IssueId)
                .ForeignKey("dbo.Priorities", t => t.PriorityId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.RootCausals", t => t.RootCausalProcessId)
                .ForeignKey("dbo.StatusIssues", t => t.StatusId)
                .ForeignKey("dbo.Trackers", t => t.TrackerId)
                .Index(t => t.ProjectId)
                .Index(t => t.TrackerId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.CategoryId)
                .Index(t => t.DetectedProcessId)
                .Index(t => t.RootCausalProcessId)
                .Index(t => t.ParentIssue_IssueId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetectedProcesses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        ParentProjectId = c.String(),
                        IsDeleted = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RootCausals",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusIssues",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trackers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IssueUsers",
                c => new
                    {
                        IssueId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        FlowTypeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.IssueId, t.UserId })
                .ForeignKey("dbo.FlowTypes", t => t.FlowTypeId)
                .Index(t => t.FlowTypeId);
            
            CreateTable(
                "dbo.FlowTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IssueUser",
                c => new
                    {
                        IssueId = c.String(nullable: false, maxLength: 50),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.IssueId, t.UserId })
                .ForeignKey("dbo.Issue", t => t.IssueId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.IssueId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssueUsers", "FlowTypeId", "dbo.FlowTypes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.IssueUser", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.IssueUser", "IssueId", "dbo.Issue");
            DropForeignKey("dbo.Issue", "TrackerId", "dbo.Trackers");
            DropForeignKey("dbo.Issue", "StatusId", "dbo.StatusIssues");
            DropForeignKey("dbo.Issue", "RootCausalProcessId", "dbo.RootCausals");
            DropForeignKey("dbo.Issue", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Issue", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.Issue", "ParentIssue_IssueId", "dbo.Issue");
            DropForeignKey("dbo.Issue", "DetectedProcessId", "dbo.DetectedProcesses");
            DropForeignKey("dbo.Issue", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.IssueUser", new[] { "UserId" });
            DropIndex("dbo.IssueUser", new[] { "IssueId" });
            DropIndex("dbo.IssueUsers", new[] { "FlowTypeId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Issue", new[] { "ParentIssue_IssueId" });
            DropIndex("dbo.Issue", new[] { "RootCausalProcessId" });
            DropIndex("dbo.Issue", new[] { "DetectedProcessId" });
            DropIndex("dbo.Issue", new[] { "CategoryId" });
            DropIndex("dbo.Issue", new[] { "PriorityId" });
            DropIndex("dbo.Issue", new[] { "StatusId" });
            DropIndex("dbo.Issue", new[] { "TrackerId" });
            DropIndex("dbo.Issue", new[] { "ProjectId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.IssueUser");
            DropTable("dbo.FlowTypes");
            DropTable("dbo.IssueUsers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Trackers");
            DropTable("dbo.StatusIssues");
            DropTable("dbo.RootCausals");
            DropTable("dbo.Projects");
            DropTable("dbo.Priorities");
            DropTable("dbo.DetectedProcesses");
            DropTable("dbo.Categories");
            DropTable("dbo.Issue");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
