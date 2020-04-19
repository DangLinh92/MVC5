using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;
using Redmine.Models;

namespace Redmine.Core.Domain
{
    [Table("IssueUsers")]
    public class IssueUser
    {
        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string IssueId { get; set; }

        [Column(Order = 2)]
        public string FlowTypeId { get; set; }

        [ForeignKey("FlowTypeId")]
        public virtual FlowType FlowType { get; set; }

        [ForeignKey("IssueId")]
        public Issue Issue { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}