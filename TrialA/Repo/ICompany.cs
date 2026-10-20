using TrialA.DTOs;
using TrialA.Models;

namespace TrialA.Repo
{
    public interface ICompany:IGenaricRepo<Company>
    {
        public Task<GeaterCompanyDTO> Greaternumberofjops();
    }
}
