using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Redmine.Models;

namespace Redmine.Core.Domain
{
    [Table("Issue")]
    public class Issue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Required]
        [MaxLength(50)]
        [DisplayName("Issue")]
        public string IssueId { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Project")]
        public string ProjectId { get; set; }

        [Required]
        [DisplayName("Tracker")]
        public string TrackerId { get; set; }

        [Required]
        [DisplayName("Status")]
        public string StatusId { get; set; }

        [Required]
        [DisplayName("Priority")]
        public string PriorityId { get; set; }

        [Required]
        [DisplayName("Category")]
        public string CategoryId { get; set; }

        [Required]
        [DisplayName("ParentTask")]
        public string ParentTaskId { get; set; }

        [Required]
        [DisplayName("DetectedProcess")]
        public string DetectedProcessId { get; set; }

        [Required]
        [DisplayName("RootCausalProcess")]
        public string RootCausalProcessId { get; set; }

        public string RelatedIssue { get; set; }// IssueId1-IssueId2-IssueId3

        [MaxLength(250)]
        public string Subject { get; set; }

        public DateTime? DueDate { get; set; }

        [Range(0,100)]
        public int? PercentDone { get; set; }

        public double? EstimateTime { get; set; }

        public double? SpendTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Description { get; set; }

        [Range(0,10)]
        public double FunctionPoint { get; set; }
        public string Remark { get; set; }

        public int? IsDeleted { get; set; }

        public virtual Project Project { get; set; }
        public virtual RootCausal RootCausal { get; set; }
        public virtual Tracker Tracker { get; set; }
        public virtual Category Category { get; set; }
        public virtual StatusIssue StatusIssue { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual DetectedProcess DetectedProcess { get; set; }
        public virtual Issue ParentIssue { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

    }
}