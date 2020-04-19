using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Redmine.Core.Domain
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string MessageId { get; set; }

        [Required]
        public string IssueId { get; set; }

        [Required]
        [DisplayName("Update by")]
        public string UpdateBy { get; set; }

        public DateTime? UpDateTime { get; set; }

        public string Content { get; set; }

        [DisplayName("Message Parent")]
        public string ParentId { get; set; }

        public string IsDeleted { get; set; }

        [ForeignKey("IssueId")]
        public Issue Issue { get; set; }
    }
}