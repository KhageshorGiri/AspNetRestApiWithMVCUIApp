using Catelog.API.Dtos.UserDtos;
using Catelog.API.Interfaces;
using Catelog.API.Models;
using Catelog.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catelog.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {

        private readonly IUserManagement _userManagementService;

        public UserController(IUserManagement userManagementService)
        {
            this._userManagementService = userManagementService;
        }

        [HttpPost]
        [Route("/signup")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterUser(CreateUserDto createUserDto)
        {
            User user = new()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                UserName = createUserDto.UserName,
                PostalCode = createUserDto.PostalCode
            };
            await _userManagementService.CreateUserAsync(user);
            return Ok();
        }
    }
}
