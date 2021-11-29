using GX2.DigitalLibrary.DTO.Models;
using GX2.DigitalLibrary.Interfaces;
using GX2.DigitalLibrary.ViewModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;


        public AccountController(IAccountService accountService) =>
            (_accountService) = (accountService);


        [Route("[action]")]
        [HttpPost()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "ModelState is false." });
            try
            {
                var result = await _accountService.RegisterAsync(register);

                if (result)
                    return Ok(new { message = "Usuário adicionado com sucesso." });

                return BadRequest(new { message = "Usuário não foi adicionado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Route("[action]")]
        [HttpPost()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "ModelState is false." });
            try
            {
                var result = await _accountService.UpdateAsync(model);

                if (result)
                    return Ok(new { message = "Usuário atualizado com sucesso." });

                return BadRequest(new { message = "Usuário não foi atualizado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Route("[action]/{id}")]
        [HttpDelete()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            try
            {
                var result = await _accountService.DeleteAsync(id);
                
                if (result)
                    return Ok(new { message = "Usuário removido com sucesso." });

                return BadRequest(new { message = "Usuário não foi removido com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
