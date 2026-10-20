using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA.DTOs;
using TrialA.Repo;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateProfileController : ControllerBase
    {
        private readonly IUnitWork _unit;
        private readonly IMapper _mapper;

        public CandidateProfileController(IUnitWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, UpdateCandidateProfiles dto)
        {
            var profile = await _unit.CandidateProfile.GetById(id);
            if (profile == null) { return NotFound(); }
            _mapper.Map(dto, profile);
            _unit.Save();
            return NoContent();
        }


    }
}
