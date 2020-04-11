using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Redmine.Core.Domain
{
    public class Tracker
    {
        public Tracker()
        {
            Issue = new HashSet<Issue>();
        }
        [Key]
        public string Id { get; set; }

        [DisplayName("Tracker")]
        public string Name { get; set; }

        public virtual ICollection<Issue> Issue { get; set; }
    }
}