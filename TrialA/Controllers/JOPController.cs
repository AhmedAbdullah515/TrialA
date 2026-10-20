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
    public class JOPController : ControllerBase
    {
        private readonly IUnitWork _unit;
        private readonly IMapper _mapper;

        public JOPController(IUnitWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        [HttpGet("GetThirdPice")]
        public async Task<IActionResult> ThirdSalary()
        {
            var jop = await _unit.Joprepo.getthird();
            if (jop == null) { return NotFound(); }
            var result = _mapper.Map<JopDTO>(jop);
            return Ok(result);
        }
        [HttpGet("ById")]
        public async Task<IActionResult> Getbyid(int id)
        {
            var jop = await _unit.Joprepo.GetById(id);
            if (jop == null) { return NotFound(); }
            var result = _mapper.Map<JopDTO>(jop);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        [Authorize(Roles =("Admin"))]
        public async Task<IActionResult> Delete(int id)
        {
            var jop = await _unit.Joprepo.GetById(id);
            if (jop == null)
            {
                return NotFound();
            }
             _unit.Joprepo.Delet(id);
            _unit.Save();
            return NoContent();
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string keyword)
        {
            var jop = await _unit.Joprepo.Search(keyword);
            if (jop == null) { return NotFound(); }
            var result = _mapper.Map<JopDTO>(jop);
            return Ok(result);
        }

    }
}
