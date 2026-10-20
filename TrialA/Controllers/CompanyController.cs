using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialA.Repo;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitWork _unit;

        public CompanyController(IUnitWork unit)
        {
            _unit = unit;
        }
        [HttpGet("GreaterCompany")]
        public async Task<IActionResult> GetGreaterCompany()
        {
            var result = await _unit.CompanyRepo.Greaternumberofjops();
            return Ok(result);
        }
    }
}
