using GX2.DigitalLibrary.DTO.Models;
using GX2.DigitalLibrary.Repositories;
using GX2.DigitalLibrary.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Repository
{
    public class AuthorRepository : IAuthorRepository, IDisposable
    {
        private readonly ApplicationContext ApplicationContext;
        private bool Disposed = false;

        public AuthorRepository(ApplicationContext applicationContext)
        {
            this.ApplicationContext = applicationContext;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return ApplicationContext.Authors;
        }

        public Author GetAuthorByID(int id)
        {
            return ApplicationContext.Authors.Find(id);
        }

        public void InsertAuthor(Author author)
        {
            ApplicationContext.Authors.Add(author);
        }

        public void DeleteAuthor(int authorID)
        {
            Author author = ApplicationContext.Authors.Find(authorID);
            ApplicationContext.Authors.Remove(author);
        }

        public void UpdateAuthor(Author author)
        {
            ApplicationContext.Entry(author).State = EntityState.Modified;
        }

        public int Save()
        {
            return ApplicationContext.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await ApplicationContext.SaveChangesAsync();
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
