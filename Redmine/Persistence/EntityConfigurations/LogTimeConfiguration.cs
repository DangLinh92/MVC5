﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Redmine.Core.Domain;

namespace Redmine.Persistence.EntityConfigurations
{
    public class LogTimeConfiguration: EntityTypeConfiguration<LogTime>
    {
        public LogTimeConfiguration()
        {
        }
    }
}