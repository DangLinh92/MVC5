using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Redmine.Core.Domain;
using Redmine.Persistence.EntityConfigurations;

namespace Redmine.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("RedmineConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new IssueConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<RootCausal> RootCausals { get; set; }
        public virtual DbSet<Tracker> Trackers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<StatusIssue> StatusIssues { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<DetectedProcess> DetectedProcesses { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<FlowType> FlowTypes { get; set; }
        public virtual DbSet<LogTime> LogTimes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<UserProject> UserProjects { get; set; }
        public virtual DbSet<IssueUser> IssueUsers { get; set; }
        public virtual DbSet<HistoryIssue> HistoryIssues { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
    }
}