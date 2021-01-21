using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChatApplication.Dtos;
using ChatApplication.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ChatApplication.Models;

namespace ChatApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {

            Console.WriteLine(registerDto);

            registerDto.Email = registerDto.Email.ToLower();
            if (await _repo.UserExists(registerDto.Email))
                return BadRequest("Email already exists");


            

            var userToCreate = _mapper.Map<TblUser>(registerDto);
            var createdUser = await _repo.Register(userToCreate);
            return StatusCode(201, new { email = createdUser.Email, firstname = createdUser.FirstName, lastname = createdUser.LastName });
            //return StatusCode(201, new { email = registerDto.Email, firstname = registerDto.FirstName, lastname = registerDto.LastName });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var userFromRepo = await _repo.Login(loginDto.Email.ToLower());
            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.UserId.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Email)
            };

            System.Console.Write(claims);

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token), email = userFromRepo.Email, fisrtname = userFromRepo.FirstName, userFromRepo.LastName });
        }
    }
}
