using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Redmine.Core.Domain
{
    public class Category
    {
        [Key]
        public string Id { get; set; }

        [DisplayName("Category")]
        public string Name { get; set; }

        public Category()
        {
            Issue = new HashSet<Issue>();
        }
        public virtual ICollection<Issue> Issue { get; set; }
    }
}