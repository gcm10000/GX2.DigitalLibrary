using GX2.DigitalLibrary.DTO.Models;
using GX2.DigitalLibrary.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Repositories.Repository
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private readonly ApplicationContext ApplicationContext;
        private bool Disposed = false;

        public BookRepository(ApplicationContext applicationContext)
        {
            this.ApplicationContext = applicationContext;
        }
        
        public IEnumerable<Book> GetBooks()
        {
            return ApplicationContext.Books;
        }

        public Book GetBookByID(int id)
        {
            return ApplicationContext.Books.Find(id);
        }

        public Book GetIncludeBookByID(int id)
        {
            return ApplicationContext.Books.Include(x => x.BookUsers).FirstOrDefault(x => x.Id == id);
        }

        public void InsertBook(Book book)
        {
            ApplicationContext.Books.Add(book);
        }

        public int Save()
        {
            return ApplicationContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await ApplicationContext.SaveChangesAsync();
        }

        public void UpdateBook(Book book)
        {
            ApplicationContext.Entry(book).State = EntityState.Modified;
        }
        public void DeleteBook(int bookID)
        {
            Book book = ApplicationContext.Books.Find(bookID);
            ApplicationContext.Books.Remove(book);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    ApplicationContext.Dispose();
                }
            }
            this.Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
