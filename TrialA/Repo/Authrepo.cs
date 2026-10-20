using Microsoft.EntityFrameworkCore;
using TrialA.App_Context;
using TrialA.Models;

namespace TrialA.Repo
{
    public class Authrepo:IAuthrepo
    {
        private readonly AppDbContext _context;

        public Authrepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Email == email);
        }

    }
}
