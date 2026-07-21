using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/account")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public AcountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
                
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                    if(roleResult.Succeeded) return Ok("User created");
                    else return StatusCode(500, roleResult.Errors);
                } 
                else return StatusCode(500, createdUser.Errors);


            }  catch (Exception e)
            {
                return StatusCode(500, e);
            }         
        }



    }
}
