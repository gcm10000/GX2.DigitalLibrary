using GX2.DigitalLibrary.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Repositories.Interfaces
{
    public interface IUserRepository
    {
        bool ContainsBook(string userName, Book book);
    }
}
