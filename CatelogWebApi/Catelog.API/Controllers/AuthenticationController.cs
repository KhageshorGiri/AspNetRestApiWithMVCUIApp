using Catelog.API.Dtos.AuthenticationDtos;
using Catelog.API.Interfaces;
using Catelog.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace Catelog.API.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authenticationService;
        public AuthenticationController(IAuthentication authentication)
        {
            this._authenticationService = authentication;
        }

        // POST: /api/token
        [AllowAnonymous]
        [HttpPost]
        [Route("api/token")]
        public async Task<ActionResult> LoginUserAsync(TokenRequest tokenRequest)
        {
            // check if the user exist in db or not
            var tokenResponse = await _authenticationService.LoginUserAsync(tokenRequest);
            return Ok(tokenResponse);
        }


    }
}
