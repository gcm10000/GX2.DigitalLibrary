using GX2.DigitalLibrary.DTO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors();
        Author GetAuthorByID(int id);
        void InsertAuthor(Author author);
        void DeleteAuthor(int authorID);
        void UpdateAuthor(Author author);
        int Save();
        Task<int> SaveAsync();
        void Dispose();
    }
}
