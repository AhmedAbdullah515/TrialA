using AutoMapper;
using TrialA.DTOs;
using TrialA.Models;
using TrialA.Repo;

namespace TrialA.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User,RegisterDTO>().ReverseMap();
            CreateMap<Jop, JopDTO>().ReverseMap();
            CreateMap<Application, PatchApplicationDTO>().ReverseMap();
            CreateMap<Application, ApplicationDTO>().ReverseMap();
            CreateMap<CandidateProfile, UpdateCandidateProfiles>().ReverseMap();
        }
    }
}
