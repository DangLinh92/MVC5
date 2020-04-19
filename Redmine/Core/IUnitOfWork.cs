using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redmine.Core.Repositories;

namespace Redmine.Core
{
    public interface IUnitOfWork :IDisposable
    {
        IIssueRepository Issues { get; set; }
        IProjectRepository Projects { get; set; }

        ITrackerRepository Trackers { get; set; }
        int Complete();
    }
}
