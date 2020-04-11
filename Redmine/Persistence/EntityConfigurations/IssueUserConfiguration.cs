using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Redmine.Core.Domain;

namespace Redmine.Persistence.EntityConfigurations
{
    public class IssueUserConfiguration: EntityTypeConfiguration<IssueUser>
    {
        public IssueUserConfiguration()
        {
            HasKey(k => new {k.IssueId, k.UserId});
            HasRequired(x=>x.FlowType)
                .WithMany(i=>i.IssueUsers)
                .HasForeignKey(i=>i.FlowTypeId)
                .WillCascadeOnDelete(false);

        }
    }
}