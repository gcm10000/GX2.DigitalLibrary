using AutoMapper;
using GX2.DigitalLibrary.DTO.Models;
using GX2.DigitalLibrary.Interfaces;
using GX2.DigitalLibrary.Repositories.Interfaces;
using GX2.DigitalLibrary.Services;
using GX2.DigitalLibrary.ViewModel.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Business.Services
{
    public class AuthorService : BaseServices, IAuthorService
    {
        private readonly IMapper _mapper;
        private IAuthorRepository Repository { get; }

        public AuthorService(IConfiguration configuration, IAuthorRepository repository, IMapper mapper) : base(configuration)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<AuthorViewModel> GetAuthors()
        {
            var authors = Repository.GetAuthors();
            var ret = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorViewModel>>(authors);
            return ret;
        }

        public AuthorViewModel GetAuthorByID(int id)
        {
            var authors = Repository.GetAuthorByID(id);

            var ret = _mapper.Map<Author, AuthorViewModel>(authors);

            return ret;
        }

        public bool InsertAuthor(AuthorViewModel author)
        {
            var ret = _mapper.Map<AuthorViewModel, Author>(author);
            ret.Id = 0;
            ret.RefreshDate = ret.CreateDate = DateTime.Now;
            try
            {
                Repository.InsertAuthor(ret);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteAuthor(int authorID)
        {
            if (Repository.GetAuthorByID(authorID) == null)
                return false;

            Repository.DeleteAuthor(authorID);

            return true;
        }

        public bool UpdateAuthor(AuthorViewModel author)
        {
            var ret = _mapper.Map<AuthorViewModel, Author>(author);
            ret.RefreshDate = DateTime.Now;
            if (Repository.GetAuthorByID(author.Id) != null)
            {
                Repository.UpdateAuthor(ret);
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
