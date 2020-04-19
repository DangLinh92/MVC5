using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Redmine.Core.Domain
{
    public class FlowType
    {
        [Key]
        public string Id { get; set; }

        [DisplayName("FlowType")]
        public string Name { get; set; }
        public virtual ICollection<IssueUser> IssueUsers { get; set; }
    }
}