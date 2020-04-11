using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Redmine.Core.Domain;
using Redmine.Models;
using Redmine.Persistence.EntityConfigurations;

namespace Redmine.Persistence
{
    public partial class ApplicationDbContext
    {

        public virtual DbSet<RootCausal> RootCausals { get; set; }
        public virtual DbSet<Tracker> Trackers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual  DbSet<StatusIssue> StatusIssues { get; set; }
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