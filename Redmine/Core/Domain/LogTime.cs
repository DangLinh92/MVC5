using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Redmine.Core.Domain
{
    public class LogTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string IssueId { get; set; }

        public DateTime Date { get; set; }

        public double Hours { get; set; }

        public string Comment { get; set; }

        public int ActivityId { get; set; }

        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }

        [ForeignKey("IssueId")]
        public virtual Issue Issue { get; set; }
    }
}