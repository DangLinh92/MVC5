using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Redmine.Models;

namespace Redmine.Core.Domain
{
    public class UserProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string ProjectId { get; set; }

        public string RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual IdentityRole Role { get; set; }

        [ForeignKey("UserId")]

        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}