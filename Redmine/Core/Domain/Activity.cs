﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Redmine.Core.Domain
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Activity")]
        public string Name { get; set; }
    }
}