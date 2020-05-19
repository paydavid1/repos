using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ETProject.api.Features.Users
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class AuthController : ControllerBase
    {
        private readonly AuthAppServices authAppServices;
        private readonly IConfiguration config;
        public AuthController(AuthAppServices authAppServices, IConfiguration config)
        {
            this.config = config;
            this.authAppServices = authAppServices;

        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDto userDto)
        {

            if (await authAppServices.UserExistAsync(userDto.UserId.ToLower()))
                return BadRequest("User Name already Exist");

            return Ok(await authAppServices.Register(userDto));


        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserDto userDto)
        {

            UserDto user = await authAppServices.Login(userDto.UserId.ToLower(), userDto.Password);
            if (user == null)
                return Unauthorized();


            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserId)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds


            };

            var  tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new{
                token  = tokenHandler.WriteToken(token)

            });



        
            


        }

    }
}