﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Redmine.Core.Domain;
using Redmine.Core.Repositories;
using Redmine.Models;

namespace Redmine.Persistence.Repositories
{
    public class IssueReponsitory : Repository<Issue>, IIssueRepository
    {
        public IssueReponsitory(ApplicationDbContext context):base(context)
        {
            
        }
    }
}