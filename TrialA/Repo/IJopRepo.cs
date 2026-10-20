using TrialA.Models;

namespace TrialA.Repo
{
    public interface IJopRepo:IGenaricRepo<Jop>
    {
        public Task<Jop> getthird();
        public Task<Jop> Search(string keyWord);
    }
}
