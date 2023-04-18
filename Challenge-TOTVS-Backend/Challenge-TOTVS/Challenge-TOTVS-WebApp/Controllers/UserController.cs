using Challenge.TOTVS.Domain.Constants;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Domain.Models.Auth;
using Challenge.TOTVS.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.TOTVS.WebApp.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public async Task<ActionResult> Authenticated() => Ok(JsonSerializer.Serialize(String.Format("Hello {0}, Welcome!", User?.Identity?.Name)));

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<Token>> Authenticate([FromBody] LoginVM model)
        {
            var token = await _userService.AuthenticateAsync(model);
            return Ok(token);
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = Roles.Adm)]
        public async Task<ActionResult<string>> Create([FromBody] User model)
        {
            await _userService.Add(model);
            return Ok(JsonSerializer.Serialize("Account created with success!"));
        }


        [HttpPost]
        [Route("recoverPassword")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> RecoverPassword([FromBody] string email)
        {
            await _userService.RecoverEmail(email);
            return Ok(JsonSerializer.Serialize("Link to recover password sended to your e-mail, you have 5 minutes to validate"));
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = Roles.Adm)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        [Route("updatePassword/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> UpdatePassword([FromRoute] Guid id, [FromBody] string password)
        {
            await _userService.UpdatePassword(id, password);
            return Ok(JsonSerializer.Serialize("Password update with success!\nLog in with new password"));
        }
    }
}
