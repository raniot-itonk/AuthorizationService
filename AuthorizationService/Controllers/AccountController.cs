using System;
using System.Threading.Tasks;
using AuthorizationService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserSignUpRequest user)
        {
            try
            {
                var identityUser = new User {FirstName = user.FirstName, UserName = user.Email, Email = user.Email, IsStockProvider = user.IsStockProvider};
                return Ok(await _userManager.CreateAsync(identityUser, user.Password));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}