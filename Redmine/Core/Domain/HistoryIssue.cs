using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Redmine.Core.Domain
{
    public class HistoryIssue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string IssueId { get; set; }

        [DisplayName("TrackerOld")]
        public string TrackerId { get; set; }

        public string TrackerIdNew { get; set; }

        [DisplayName("StatusOld")]
        public string StatusId { get; set; }
        public string StatusIdNew { get; set; }

        [DisplayName("PriorityOld")]
        public string PriorityId { get; set; }
        public string PriorityIdNew { get; set; }

        [DisplayName("CategoryOld")]
        public string CategoryId { get; set; }

        public string CategoryIdNew { get; set; }

        [MaxLength(250)]
        public string Subject { get; set; }

        [MaxLength(250)]
        public string SubjectNew { get; set; }

        public DateTime? DueDate { get; set; }
        public DateTime? DueDateNew { get; set; }

        [Range(0, 100)]
        public int? PercentDone { get; set; }

        [Range(0, 100)]
        public int? PercentDoneNew { get; set; }

        public double? EstimateTime { get; set; }
        public double? EstimateTimeNew { get; set; }

        public double? SpendTime { get; set; }
        public double? SpendTimeNew { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StartDateNew { get; set; }

        [Range(0, 10)]
        public double FunctionPoint { get; set; }
        public double FunctionPointNew { get; set; }
        public string Remark { get; set; }
        public string RemarkNew { get; set; }

        [Required]
        public string UpdateById { get; set; }

        [Required]
        public DateTime UpdateTime { get; set; }
    }
}