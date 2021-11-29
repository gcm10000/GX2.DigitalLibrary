using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Repositories.Interfaces
{
    public interface IMovementBookRepository
    {
        void AddBookToUser(string userId, int bookId);
        void RemoveBookToUser(string userId, int bookId);
    }
}
