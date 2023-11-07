using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NewsPortal.WebAppApi.Data;
using NewsPortal.WebAppApi.Models;
using NewsPortal.WebAppApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewsPortal.WebAppApi.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
	[Authorize]
    public class UsersController : ControllerBase
    {
		private readonly IUsersRepository usersRepository;
		private readonly IConfiguration configuration;

		public UsersController(IConfiguration configuration, IUsersRepository usersRepository) {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        }

		[Route("{id}")]
		[HttpGet]
		public async Task<ActionResult<User>> GetUser(string id)
		{
			var user = await usersRepository.GetUser(id);

			if (user == null)
				return NotFound();

			return Ok(user);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
		{
			var users = await usersRepository.ListUsers();

			return Ok(users);
		}


		[Route("email/{email}")]
		[HttpGet]
		public async Task<ActionResult<User>> GetUserByEmail(string email)
		{
			var user = await usersRepository.GetUserByEmail(email);

			if (user == null) 
			{
				return NotFound();
			}

			return Ok(user);
		}

		[HttpPut]
		public async Task<ActionResult<User>> UpdateUser([FromBody] User user)
		{
			if (user == null) return BadRequest();

			var userToUpdate = await usersRepository.UpdateUser(user);

			if (userToUpdate == null) 
			{
				return NotFound();
			}

			var updated = await usersRepository.UpdateUser(userToUpdate);

			return Ok(updated);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<ActionResult> DeleteUser(string id)
		{
			var user = usersRepository.GetUser(id);

			if (user == null) 
			{
				return NotFound();
			}

			var isSuccess = await usersRepository.DeleteUser(id);

			if (!isSuccess)
			{
				return NotFound();
			}

			return NoContent();
		}


		[HttpPost, Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]User userInfo)
        {
            if (userInfo == null)
            {
                return BadRequest("Bad client request");
            }

            var user = await usersRepository.GetUserByEmail(userInfo.EmailAddress);

            if (user.Password != userInfo.Password) 
            {
				return Unauthorized();
			}

			var tokenString = CreatingToken();

			return Ok(new { Token = tokenString });
		}

        [HttpPost, Route("register")]
		[AllowAnonymous]
		public async Task<IActionResult> Register([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest("Bad client request");
            }

            try
            {
                await usersRepository.AddUser(user);
                var tokenString = CreatingToken();
                return Ok(new { Token = tokenString });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
        private string CreatingToken()
        {
			var tokenSettings = configuration.GetSection("Token");
			SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            SigningCredentials signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken tokeOptions = new JwtSecurityToken(
                    issuer: tokenSettings["ValidIssuer"],
					audience: tokenSettings["ValidAudience"],
					claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }


}

