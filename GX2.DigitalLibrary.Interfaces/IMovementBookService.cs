using GX2.DigitalLibrary.ViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Interfaces
{
    public interface IMovementBookService
    {
        bool Reserve(BookViewModel bookViewModel);
        bool Return(BookViewModel bookViewModel);
        int Save();
        Task<int> SaveAsync();
    }
}
