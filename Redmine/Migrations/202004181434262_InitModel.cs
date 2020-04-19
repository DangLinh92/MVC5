namespace Redmine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.DetectedProcesses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IssueUsers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        IssueId = c.String(nullable: false, maxLength: 50),
                        FlowTypeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.IssueId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.FlowTypes", t => t.FlowTypeId)
                .ForeignKey("dbo.Issue", t => t.IssueId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.IssueId)
                .Index(t => t.FlowTypeId);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.FlowTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.String(nullable: false),
                        IssueId = c.String(nullable: false, maxLength: 50),
                        UpdateBy = c.String(nullable: false),
                        UpDateTime = c.DateTime(),
                        Content = c.String(),
                        ParentId = c.String(),
                        IsDeleted = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issue", t => t.IssueId, cascadeDelete: true)
                .Index(t => t.IssueId);
            
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
                        ParentProjectId = c.String(maxLength: 128),
                        IsDeleted = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ParentProjectId)
                .Index(t => t.ParentProjectId);
            
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
                "dbo.HistoryIssues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssueId = c.String(),
                        TrackerId = c.String(),
                        TrackerIdNew = c.String(),
                        StatusId = c.String(),
                        StatusIdNew = c.String(),
                        PriorityId = c.String(),
                        PriorityIdNew = c.String(),
                        CategoryId = c.String(),
                        CategoryIdNew = c.String(),
                        Subject = c.String(maxLength: 250),
                        SubjectNew = c.String(maxLength: 250),
                        DueDate = c.DateTime(),
                        DueDateNew = c.DateTime(),
                        PercentDone = c.Int(),
                        PercentDoneNew = c.Int(),
                        EstimateTime = c.Double(),
                        EstimateTimeNew = c.Double(),
                        SpendTime = c.Double(),
                        SpendTimeNew = c.Double(),
                        StartDate = c.DateTime(),
                        StartDateNew = c.DateTime(),
                        FunctionPoint = c.Double(nullable: false),
                        FunctionPointNew = c.Double(nullable: false),
                        Remark = c.String(),
                        RemarkNew = c.String(),
                        UpdateById = c.String(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssueId = c.String(nullable: false, maxLength: 50),
                        Date = c.DateTime(nullable: false),
                        Hours = c.Double(nullable: false),
                        Comment = c.String(),
                        ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Issue", t => t.IssueId, cascadeDelete: true)
                .Index(t => t.IssueId)
                .Index(t => t.ActivityId);
            
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
                "dbo.UserProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ProjectId = c.String(maxLength: 128),
                        RoleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProjects", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProjects", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LogTimes", "IssueId", "dbo.Issue");
            DropForeignKey("dbo.LogTimes", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.Issue", "TrackerId", "dbo.Trackers");
            DropForeignKey("dbo.Issue", "StatusId", "dbo.StatusIssues");
            DropForeignKey("dbo.Issue", "RootCausalProcessId", "dbo.RootCausals");
            DropForeignKey("dbo.Issue", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ParentProjectId", "dbo.Projects");
            DropForeignKey("dbo.Issue", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.Issue", "ParentIssue_IssueId", "dbo.Issue");
            DropForeignKey("dbo.Messages", "IssueId", "dbo.Issue");
            DropForeignKey("dbo.IssueUsers", "IssueId", "dbo.Issue");
            DropForeignKey("dbo.IssueUsers", "FlowTypeId", "dbo.FlowTypes");
            DropForeignKey("dbo.IssueUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Issue", "DetectedProcessId", "dbo.DetectedProcesses");
            DropForeignKey("dbo.Issue", "CategoryId", "dbo.Categories");
            DropIndex("dbo.UserProjects", new[] { "RoleId" });
            DropIndex("dbo.UserProjects", new[] { "ProjectId" });
            DropIndex("dbo.UserProjects", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LogTimes", new[] { "ActivityId" });
            DropIndex("dbo.LogTimes", new[] { "IssueId" });
            DropIndex("dbo.Projects", new[] { "ParentProjectId" });
            DropIndex("dbo.Messages", new[] { "IssueId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.IssueUsers", new[] { "FlowTypeId" });
            DropIndex("dbo.IssueUsers", new[] { "IssueId" });
            DropIndex("dbo.IssueUsers", new[] { "UserId" });
            DropIndex("dbo.Issue", new[] { "ParentIssue_IssueId" });
            DropIndex("dbo.Issue", new[] { "RootCausalProcessId" });
            DropIndex("dbo.Issue", new[] { "DetectedProcessId" });
            DropIndex("dbo.Issue", new[] { "CategoryId" });
            DropIndex("dbo.Issue", new[] { "PriorityId" });
            DropIndex("dbo.Issue", new[] { "StatusId" });
            DropIndex("dbo.Issue", new[] { "TrackerId" });
            DropIndex("dbo.Issue", new[] { "ProjectId" });
            DropTable("dbo.UserProjects");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LogTimes");
            DropTable("dbo.HistoryIssues");
            DropTable("dbo.Trackers");
            DropTable("dbo.StatusIssues");
            DropTable("dbo.RootCausals");
            DropTable("dbo.Projects");
            DropTable("dbo.Priorities");
            DropTable("dbo.Messages");
            DropTable("dbo.FlowTypes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.IssueUsers");
            DropTable("dbo.DetectedProcesses");
            DropTable("dbo.Issue");
            DropTable("dbo.Categories");
            DropTable("dbo.Activities");
        }
    }
}
