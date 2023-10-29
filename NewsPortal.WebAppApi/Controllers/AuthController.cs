using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NewsPortal.WebAppApi.Data;
using NewsPortal.WebAppApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewsPortal.WebAppApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController(DataContext context) {
            _context = context;
        }
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]User user)
        {
            if(user == null)
            {
                return BadRequest("Bad client request");
            }
            foreach(var userItem in _context.Users) {
                if(user.UserName == userItem.UserName && user.Password == userItem.Password)
                {

                    var tokenString = CreatingToken();
                    return Ok( new { Token = tokenString });
                }              
            }
            return Unauthorized();
        }

        [HttpPost, Route("register")]
        public IActionResult Register([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest("Bad client request");
            }
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                var tokenString = CreatingToken();
                return Ok(new { Token = tokenString });
            }
            catch (Exception)
            {
                return Unauthorized();
            }


        }
        private string CreatingToken()
        {
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            SigningCredentials signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7021",//Saját localhost PORTJÁT írd be, kb nem fog müködni
                    audience: "https://localhost:7021",//Saját localhost PORTJÁT írd be, kb nem fog müködni
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }


}

