using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPIProject.Models;
using WebAPIProject.Services;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly IRegisterService service;
        private readonly IConfiguration configuration;
        public RegisterController(IRegisterService service,IConfiguration configuration)
        {
            this.service = service;
            this.configuration = configuration;
        }
        [HttpPost]
        [Route("Login")]

        public async Task<Hashtable> Post(Register r)
        {
            Hashtable hashtable = new Hashtable();
            try
            {
                var list = await service.GetLogin(r);
                if (list != null)
                {
                    var token = GenerateToken(list);
                    hashtable.Add("Token", token);
                    hashtable.Add("Object", list);
                    return hashtable;
                }
                   /* return StatusCode(StatusCodes.Status200OK);*/
               /* else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }*/
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                await Console.Out.WriteLineAsync(ex.Message);
            }
            return hashtable;
        }

        [HttpPost]
        [Route("Registration")]

        public async Task<IActionResult> Post1([FromBody][Bind(include: "Rid,UserName,Email,Gender,PhoneNumber,City,Password")] Register user)
        {
            try
            {
                var result = await service.Register(user);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        private string GenerateToken(Register reg)
        { 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier,reg.UserName),
        new Claim(ClaimTypes.Role,reg.Roleid.ToString()),
    };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
