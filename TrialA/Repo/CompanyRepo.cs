using Microsoft.EntityFrameworkCore;
using TrialA.App_Context;
using TrialA.DTOs;
using TrialA.Models;

namespace TrialA.Repo
{
    public class CompanyRepo : GenariceRepo<Company>, ICompany
    {
        public CompanyRepo(AppDbContext context) : base(context)
        {
        }

        

       public async Task<GeaterCompanyDTO> Greaternumberofjops()
        {
            return await _context.Companys
                .Select(company => new GeaterCompanyDTO { Jopscount = company.Jops.Count(), Name = company.Name })
                .OrderByDescending(a=>a.Jopscount).FirstOrDefaultAsync();
        }
    }
}
