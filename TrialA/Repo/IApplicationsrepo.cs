using TrialA.Models;

namespace TrialA.Repo
{
    public interface IApplicationsrepo:IGenaricRepo<Application>
    {
        public Task<List<Application>> GetApplicationifsubmited();
    }
}
