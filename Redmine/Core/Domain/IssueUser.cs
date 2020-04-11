using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Redmine.Core.Domain
{
    public class IssueUser
    {
        public string UserId { get; set; }
        public string IssueId { get; set; }
        public string FlowTypeId { get; set; }

        public virtual FlowType FlowType { get; set; }
    }
}