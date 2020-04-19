using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Redmine.Core.Domain
{
    public class Project
    {
        public Project()
        {
            Issue = new HashSet<Issue>();
        }
        [Key]
        public string Id { get; set; }

        [DisplayName("Project")]
        public string Name { get; set; }

        [DisplayName("Parent Project")]
        public string ParentProjectId { get; set; }

        public string IsDeleted { get; set; }

        public virtual ICollection<Issue> Issue { get; set; }

        [ForeignKey("ParentProjectId")]
        public virtual Project ParentProject { get; set; }
    }
}