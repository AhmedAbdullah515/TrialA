using TrialA.Models;

namespace TrialA.Repo
{
    public interface IAuthrepo
    {
        public Task<User> GetByEmail(string email);
    }
}
