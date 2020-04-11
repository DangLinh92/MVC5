using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

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
        public virtual IdentityRole IdentityRole { get; set; }
    }
}