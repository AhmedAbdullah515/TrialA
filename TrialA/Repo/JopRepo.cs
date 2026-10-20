using Microsoft.EntityFrameworkCore;
using TrialA.App_Context;
using TrialA.Models;

namespace TrialA.Repo
{
    public class JopRepo : GenariceRepo<Jop>, IJopRepo
    {
        public JopRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<Jop> getthird()
        {
            return await _context.Jops.OrderByDescending(a => a.Salary).Skip(2).Take(1).FirstOrDefaultAsync();
        }
        public async Task<Jop> Search(string keyWord)
        {
            return await _context.Jops.Where(a => a.Title.Contains(keyWord) || a.Description.Contains(keyWord)).FirstOrDefaultAsync();
        }

    }
}
