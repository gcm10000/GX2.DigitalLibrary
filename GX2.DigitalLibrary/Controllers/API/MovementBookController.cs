using GX2.DigitalLibrary.DTO.Models;
using GX2.DigitalLibrary.Interfaces;
using GX2.DigitalLibrary.ViewModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementBookController : ControllerBase
    {
        private readonly IMovementBookService _movementService;

        public MovementBookController(IMovementBookService movementService)
        {
            _movementService = movementService;
        }

        [Route("[action]")]
        [HttpPost()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
        public async Task<IActionResult> Reserve([FromBody] BookViewModel book)
        {
            var result = _movementService.Reserve(book);
            if (result)
            {
                await _movementService.SaveAsync();
                return Ok(new { message = "Livro reservado com sucesso." });
            }

            return BadRequest(new { message = "Erro ao reservar livro." });
        }

        [Route("[action]")]
        [HttpPost()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]
        public async Task<IActionResult> Return([FromBody] BookViewModel book)
        {
            var result = _movementService.Return(book);
            if (result)
            {
                await _movementService.SaveAsync();
                return Ok(new { message = "Livro retornado com sucesso." });
            }

            return BadRequest(new { message = "Erro ao retornar livro." });
        }
    }
}
