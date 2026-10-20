using TrialA.App_Context;
using TrialA.Models;

namespace TrialA.Repo
{
    public class UniOfWork:IUnitWork
    {

        private readonly AppDbContext _context;

        public UniOfWork(AppDbContext context, IGenaricRepo<User> userRepo,ICompany companyRepo, IJopRepo joprepo, IGenaricRepo<CandidateProfile> candidateProfile, IApplicationsrepo applicationRepo, IAuthrepo authRepo)
        {
            _context = context;
            UserRepo = userRepo;
            CompanyRepo = companyRepo;
            Joprepo = joprepo;
            CandidateProfile = candidateProfile;
            ApplicationRepo = applicationRepo;
            AuthRepo = authRepo;
        }

        public IGenaricRepo<User> UserRepo { get; }
        public ICompany CompanyRepo { get; }
        public IJopRepo Joprepo { get; }
        public IGenaricRepo<CandidateProfile> CandidateProfile { get; }
        public IApplicationsrepo ApplicationRepo { get; }
        public IAuthrepo AuthRepo { get; }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
