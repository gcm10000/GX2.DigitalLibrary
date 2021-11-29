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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext ApplicationContext;

        public UserRepository(ApplicationContext applicationContext)
        {
            this.ApplicationContext = applicationContext;
        }


        public bool ContainsBook(string userName, Book book)
        {
            var user = ApplicationContext.ApplicationUser
                                         .FirstOrDefault(x => x.UserName == userName);

            var bu = ApplicationContext.BookUsers;
            
            return bu.Any(x => x.BookId == book.Id);
        }
    }
}
