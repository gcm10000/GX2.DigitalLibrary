using GX2.DigitalLibrary.DTO.Models;
using GX2.DigitalLibrary.ViewModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Interfaces
{
    public interface IAuthorService
    {
        public IEnumerable<AuthorViewModel> GetAuthors();
        AuthorViewModel GetAuthorByID(int id);
        bool InsertAuthor(AuthorViewModel author);
        bool DeleteAuthor(int authorID);
        bool UpdateAuthor(AuthorViewModel author);
        int Save();
        Task<int> SaveAsync();

        void Dispose();
    }
}
