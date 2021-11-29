using GX2.DigitalLibrary.ViewModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Interfaces
{
    public interface IBookService
    {
        public IEnumerable<BookViewModel> GetBooks();
        BookViewModel GetBookByID(int id);
        bool InsertBook(BookViewModel Book);
        bool DeleteBook(int BookID);
        bool UpdateBook(BookViewModel Book);
        int Save();
        Task<int> SaveAsync();

        void Dispose();
    }
}
