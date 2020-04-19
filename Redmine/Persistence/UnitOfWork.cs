using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Redmine.Core;
using Redmine.Core.Repositories;
using Redmine.Models;
using Redmine.Persistence.Repositories;

namespace Redmine.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Issues = new IssueReponsitory(context);
            Projects = new ProjectRepository(context);
            Trackers = new TrackerRepository(context);
        }

        public IIssueRepository Issues { get; set; }
        public IProjectRepository Projects { get; set; }
        public ITrackerRepository Trackers { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}