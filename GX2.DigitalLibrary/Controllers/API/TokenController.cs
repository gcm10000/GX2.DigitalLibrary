using GX2.DigitalLibrary.Interfaces;
using GX2.DigitalLibrary.Services.Services;
using GX2.DigitalLibrary.ViewModel;
using GX2.DigitalLibrary.ViewModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public TokenController(IAccountService accountService, ITokenService tokenService) => 
            (_accountService, _tokenService) = (accountService, tokenService);

        [Route("v1/access-token")]
        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> AccessToken(CredentialViewModel credential)
        {
            try
            {
                var result = await _accountService.ValidateAsync(credential.Username, credential.Password);

                if (!result)
                    return BadRequest(new { message = "Usuário ou senha inválidos." });

                var role = await _accountService.GetUserRoleAsync(credential.Username);

                int seconds = 4 * 60 * 60;
                var token = _tokenService.GenerateToken(DateTime.UtcNow.AddSeconds(seconds), credential.Username, role);

                AccessTokenResponseViewModel tokenModel = new()
                {
                    AccessToken = token,
                    ExpiresIn = seconds,
                    TokenType = "bearer"
                };

                return Ok(tokenModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
