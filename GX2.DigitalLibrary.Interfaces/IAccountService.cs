using GX2.DigitalLibrary.DTO.Models;
using GX2.DigitalLibrary.ViewModel.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Interfaces
{
    public interface IAccountService
    {
        Task<bool> ValidateAsync(string username, string password);
        Task<string> GetUserRoleAsync(string username);
        Task<bool> RegisterAsync(RegisterViewModel register);
        Task<bool> UpdateAsync(RegisterViewModel applicationUser);
        Task<bool> DeleteAsync(string id);
    }
}
