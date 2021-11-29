using GX2.DigitalLibrary.DTO.Models;
using GX2.DigitalLibrary.Interfaces;
using GX2.DigitalLibrary.ViewModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService) => 
            (_authorService) = (authorService);

        [HttpGet()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,User")]
        public IActionResult Index()
        {
            var authors = _authorService.GetAuthors();
            return Ok(authors);
        }

        [Route("{index}")]
        [HttpGet()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,User")]
        public IActionResult Find(int index)
        {
            var author = _authorService.GetAuthorByID(index);
            return Ok(author);
        }

        [Route("[action]")]
        [HttpPost()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] AuthorViewModel author)
        {
            var result = _authorService.InsertAuthor(author);
            await _authorService.SaveAsync();

            if (result)
                return Ok(new { message = "Autor adicionado com sucesso." });

            return BadRequest(new { message = "Erro ao adicionar autor." });
        }

        [Route("[action]")]
        [HttpPost()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] AuthorViewModel author)
        {
            var result = _authorService.UpdateAuthor(author);
            await _authorService.SaveAsync();

            if (result)
                return Ok(new { message = "Autor atualizado com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar autor." });
        }

        [Route("[action]/{id}")]
        [HttpDelete()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = _authorService.DeleteAuthor(id);
            await _authorService.SaveAsync();

            if (result)
                return Ok(new { message = "Autor apagado com sucesso." });
            
            return BadRequest(new { message = "Autor inexistente." });
        }

    }
}
