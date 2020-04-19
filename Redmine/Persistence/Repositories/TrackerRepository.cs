using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Redmine.Core.Domain;
using Redmine.Core.Repositories;
using Redmine.Models;

namespace Redmine.Persistence.Repositories
{
    public class TrackerRepository : Repository<Tracker>,ITrackerRepository
    {
        public TrackerRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}