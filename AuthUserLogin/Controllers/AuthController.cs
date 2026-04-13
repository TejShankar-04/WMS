using AuthUserLogin.Infrastructure;
using AuthUserLogin.Infrastructure.InterFace;
using AuthUserLogin.Model;
using AuthUserLogin.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthUserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthDbClass _uthDbContext;
        private readonly ITokenServices _tokenServices;

        public AuthController(IAuthDbClass authDbContext, ITokenServices tokenServices)
        {
            _uthDbContext = authDbContext;
            _tokenServices = tokenServices;
        }
        [AllowAnonymous]
        [HttpPost("Gettoken")]
        public async Task<IActionResult> GetToken([FromBody] UserDto userDto)
        {
            var userDetails = await _uthDbContext.users.Where(x => x.Email == userDto.Email && x.Password == userDto.Password).FirstOrDefaultAsync();
            if (userDetails != null)
            {
                var token = _tokenServices.CreateToken(userDetails.Name);
                return Ok(token);
            }
            else
            {
                return NotFound("User Not Fond");
            }
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUsers([FromBody] AddUser addUser)
        {
            if (addUser == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            var existingUser = await _uthDbContext.users
                .FirstOrDefaultAsync(x => x.Email == addUser.Email);

            if (existingUser != null)
            {
                return BadRequest("Email already exists");
            }

            var user = new User
            {
                Email = addUser.Email,
                Password = addUser.Password,
                Name = addUser.Name,
                CreatedDate = DateTime.UtcNow
            };

            await _uthDbContext.users.AddAsync(user);
            await _uthDbContext.SaveChangesAsync();

            return Ok(new
            {
                user.Id,
                user.Name,
                user.Email
            });
        }
    }
}
