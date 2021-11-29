using GX2.DigitalLibrary.DTO.Models;
using GX2.DigitalLibrary.Interfaces;
using GX2.DigitalLibrary.Repositories.Interfaces;
using GX2.DigitalLibrary.Services;
using GX2.DigitalLibrary.ViewModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Business.Services
{
    public class MovementBookService : BaseServices, IMovementBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMovementBookRepository _movementBookRepository;

        public MovementBookService(IConfiguration configuration, IBookRepository bookRepository, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IMovementBookRepository movementBookRepository, UserManager<ApplicationUser> userManager) : base(configuration)
        {
            this._bookRepository = bookRepository;
            this._httpContextAccessor = httpContextAccessor;
            this._userRepository = userRepository;
            this._userManager = userManager;
            this._movementBookRepository = movementBookRepository;
        }

        public bool Reserve(BookViewModel bookViewModel)
        {

            var book = _bookRepository.GetIncludeBookByID(bookViewModel.Id);
            if (book != null)
            {
                if (book.Quantity > 0)
                {
                    var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                    var containsBook = _userRepository.ContainsBook(userName, book);
                    var userId = _userManager.Users.FirstOrDefault(x => x.UserName == userName).Id;
                    var bookId = book.Id;
                    if (!containsBook)
                    {
                        _movementBookRepository.AddBookToUser(userId, bookId);
                        book.Quantity--;
                        _bookRepository.UpdateBook(book);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Return(BookViewModel bookViewModel)
        {
            var book = _bookRepository.GetIncludeBookByID(bookViewModel.Id);
            if (book != null)
            {
                var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                var containsBook = _userRepository.ContainsBook(userName, book);
                var userId = _userManager.Users.FirstOrDefault(x => x.UserName == userName).Id;
                var bookId = book.Id;
                if (containsBook)
                {
                    _movementBookRepository.RemoveBookToUser(userId, bookId);
                    book.Quantity++;
                    _bookRepository.UpdateBook(book);
                    return true;
                }
            }

            return false;
        }

        public int Save()
        {
            return _bookRepository.Save();
        }

        public async Task<int> SaveAsync()
        {
            return await _bookRepository.SaveAsync();
        }
    }
}
