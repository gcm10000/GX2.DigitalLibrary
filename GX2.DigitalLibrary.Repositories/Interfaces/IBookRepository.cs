using GX2.DigitalLibrary.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Repositories.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookByID(int id);
        Book GetIncludeBookByID(int id);
        void InsertBook(Book book);
        void DeleteBook(int bookID);
        void UpdateBook(Book book);
        int Save();
        Task<int> SaveAsync();
        void Dispose();
    }
}
