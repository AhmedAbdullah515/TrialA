using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA.DTOs;
using TrialA.Models;
using TrialA.Repo;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitWork _unit;
        private IMapper _mapper;

        public ApplicationController(IUnitWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        [HttpPatch("PatchStatus")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Patch(int id,PatchApplicationDTO dto)
        {
            var application=await _unit.ApplicationRepo.GetById(id);
            if (application == null)
            {
                return NotFound();
            }
            var result = _mapper.Map(dto, application);
            _unit.Save();
            return NoContent();
        }
        [HttpGet("Submitted")]
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> getAlSubmitted()
        {
            var Applications = await _unit.ApplicationRepo.GetApplicationifsubmited();
            if (Applications == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<List<ApplicationDTO>>(Applications);
            return Ok(result);
        }
    }
}
