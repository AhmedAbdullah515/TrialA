using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TrialA.DTOs;
using TrialA.Models;
using TrialA.Repo;

namespace TrialA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitWork _unit;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthController(IUnitWork unit, IConfiguration configuration, IMapper mapper)
        {
            _unit = unit;
            _configuration = configuration;
            _mapper = mapper;
        }
        private  string GenerateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
            var credits = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenobject = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                signingCredentials: credits,
                claims:claims,
                expires: DateTime.UtcNow.AddHours(1)
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenobject);   
        }
        [HttpPost("Login")]
        public async Task<IActionResult>Login(LoginDTO dto)
        {
            var user = await _unit.AuthRepo.GetByEmail(dto.Email);
            if (user == null)
            {
                return Unauthorized("In valid email or password");
            }
            if (user.Password != dto.Password)
            {
                return Unauthorized("Invalid Email or passowrd");
            }
            var reslt = GenerateToken(user);
            return Ok(reslt);
        }
        [HttpPost("Registeration")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var emailexist = await _unit.AuthRepo.GetByEmail(dto.Email);
            if (emailexist != null)
            {
                return BadRequest("This Email allready exists");

            }
            var user = _mapper.Map<User>(dto);
            await _unit.UserRepo.Add(user);
            _unit.Save();
            return Created();
        }
    }
}
