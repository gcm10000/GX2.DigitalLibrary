using AutoMapper;
using GX2.DigitalLibrary.Interfaces;
using GX2.DigitalLibrary.Services;
using GX2.DigitalLibrary.ViewModel.Models;
using GX2.DigitalLibrary.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GX2.DigitalLibrary.DTO.Models;

namespace GX2.DigitalLibrary.Business.Services
{
    public class BookService : BaseServices, IBookService
    {
        private readonly IMapper _mapper;
        private IBookRepository Repository { get; }

        public BookService(IConfiguration configuration, IBookRepository repository, IMapper mapper) : base(configuration)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public BookViewModel GetBookByID(int id)
        {
            var book = Repository.GetBookByID(id);
            var ret = _mapper.Map<Book, BookViewModel>(book);
            return ret;
        }

        public IEnumerable<BookViewModel> GetBooks()
        {
            var book = Repository.GetBooks();
            var ret = _mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(book);
            return ret;
        }

        public bool InsertBook(BookViewModel book)
        {
            var ret = _mapper.Map<BookViewModel, Book>(book);
            ret.Id = 0;
            ret.AuthorFK = book.AuthorId;
            ret.Author = null;
            ret.RefreshDate = ret.CreateDate = DateTime.Now;
            try
            {
                Repository.InsertBook(ret);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteBook(int bookID)
        {
            if (Repository.GetBookByID(bookID) == null)
                return false;

            Repository.DeleteBook(bookID);

            return true;
        }

        public bool UpdateBook(BookViewModel book)
        {
            var ret = _mapper.Map<BookViewModel, Book>(book);
            ret.RefreshDate = DateTime.Now;
            if (Repository.GetBookByID(book.Id) != null)
            {
                Repository.UpdateBook(ret);
                return true;
            }
            return false;
        }

        public int Save()
        {
            return Repository.Save();
        }

        public Task<int> SaveAsync()
        {
            return Repository.SaveAsync();
        }

        public void Dispose()
        {
            Repository.Dispose();
        }
    }
}
