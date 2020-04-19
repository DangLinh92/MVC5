using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Redmine.Core.Domain;

namespace Redmine.Persistence.EntityConfigurations
{
    public class IssueConfiguration: EntityTypeConfiguration<Issue>
    {
        public IssueConfiguration()
        {
            HasRequired(p=>p.Project)
                .WithMany(i=>i.Issue)
                .HasForeignKey(p=>p.ProjectId)
                .WillCascadeOnDelete(false);
            HasRequired(r=>r.RootCausal)
                .WithMany(i=>i.Issue)
                .HasForeignKey(r=>r.RootCausalProcessId)
                .WillCascadeOnDelete(false);
            HasRequired(t=>t.Tracker)
                .WithMany(i=>i.Issue)
                .HasForeignKey(t=>t.TrackerId)
                .WillCascadeOnDelete(false);
            HasRequired(c=>c.Category)
                .WithMany(i=>i.Issue)
                .HasForeignKey(c=>c.CategoryId)
                .WillCascadeOnDelete(false);
            HasRequired(st=>st.StatusIssue)
                .WithMany(i=>i.Issue)
                .HasForeignKey(st=>st.StatusId)
                .WillCascadeOnDelete(false);
            HasRequired(p=>p.Priority)
                .WithMany(i=>i.Issue)
                .HasForeignKey(p=>p.PriorityId)
                .WillCascadeOnDelete(false);
            HasRequired(d=>d.DetectedProcess)
                .WithMany(i=>i.Issue)
                .HasForeignKey(d=>d.DetectedProcessId)
                .WillCascadeOnDelete(false);
            HasRequired(i => i.ParentIssue);
        }
    }
}