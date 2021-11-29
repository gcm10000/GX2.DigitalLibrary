using GX2.DigitalLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Repositories.Repository
{
    public class MovementBookRepository : IMovementBookRepository, IDisposable
    {
        private readonly ApplicationContext ApplicationContext;
        private bool Disposed = false;

        public MovementBookRepository(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }
        public void AddBookToUser(string userId, int bookId)
        {
            ApplicationContext.BookUsers.Add(new DTO.Models.BookUser() { UserId = userId, BookId = bookId });
        }

        public void RemoveBookToUser(string userId, int bookId)
        {
            var bookUser = ApplicationContext.BookUsers.FirstOrDefault(x => (x.UserId == userId) && (x.BookId == bookId));
            ApplicationContext.BookUsers.Remove(bookUser);
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
