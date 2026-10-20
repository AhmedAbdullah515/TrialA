using Microsoft.EntityFrameworkCore;
using TrialA.App_Context;
using TrialA.Models;

namespace TrialA.Repo
{
    public class ApplicationRepo : GenariceRepo<Application>, IApplicationsrepo
    {
        public ApplicationRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Application>> GetApplicationifsubmited()
        {
            return await _context.Applications.Where(a => a.Status == ApplicationStatus.Accepted).ToListAsync();
        }
    }
}
