using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Redmine.Core.Domain;

namespace Redmine.Persistence.EntityConfigurations
{
    public class IssueUserConfiguration: EntityTypeConfiguration<IssueUser>
    {
        public IssueUserConfiguration()
        {
        }
    }
}