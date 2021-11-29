using GX2.DigitalLibrary.Interfaces;
using GX2.DigitalLibrary.ViewModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService) => (_bookService) = (bookService);

        //Get all books
        [HttpGet()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,User")]
        public IActionResult Index()
        {
            var books = _bookService.GetBooks();
            return Ok(books);
        }

        [Route("{index}")]
        [HttpGet()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,User")]
        public IActionResult Find(int index)
        {
            var book = _bookService.GetBookByID(index);
            return Ok(book);
        }

        [Route("[action]/{category}")]
        [HttpGet()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,User")]
        public IActionResult FindByCategory(string category)
        {
            var books = _bookService.GetBooks();
            var bookWhere = books.Where(x => x.Category == category);
            return Ok(bookWhere);
        }

        [Route("[action]")]
        [HttpPost()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] BookViewModel book)
        {
            var result = _bookService.InsertBook(book);
            await _bookService.SaveAsync();

            if (result)
                return Ok(new { message = "Livro adicionado com sucesso." });

            return BadRequest(new { message = "Erro ao adicionar livro." });
        }

        [Route("[action]")]
        [HttpPost()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] BookViewModel book)
        {
            var result = _bookService.UpdateBook(book);
            await _bookService.SaveAsync();

            if (result)
                return Ok(new { message = "Livro atualizado com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar livro." });
        }

        [Route("[action]/{index}")]
        [HttpDelete()]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]

        public async Task<IActionResult> Delete(int index)
        {
            var result = _bookService.DeleteBook(index);
            await _bookService.SaveAsync();

            if (result)
                return Ok(new { message = "Livro apagado com sucesso." });

            return BadRequest(new { message = "Livro inexistente." });
        }
    }
}
