using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Redmine.Core.Domain
{
    public class DetectedProcess
    {
        [Key]
        public string Id { get; set; }

        [DisplayName("DetectedProcess")]
        public string Name { get; set; }

        public DetectedProcess()
        {
            Issue = new HashSet<Issue>();
        }
        public virtual ICollection<Issue> Issue { get; set; }
    }
}