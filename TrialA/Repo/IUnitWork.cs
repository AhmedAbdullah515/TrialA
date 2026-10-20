using TrialA.Models;

namespace TrialA.Repo
{
    public interface IUnitWork
    {
        public IGenaricRepo<User>UserRepo { get; }
        public ICompany CompanyRepo { get; }
        public IJopRepo Joprepo { get; }
        public IGenaricRepo<CandidateProfile>CandidateProfile { get; }
        public IApplicationsrepo ApplicationRepo { get; }
        public IAuthrepo AuthRepo {  get; }
        public void Save();
    }
}
