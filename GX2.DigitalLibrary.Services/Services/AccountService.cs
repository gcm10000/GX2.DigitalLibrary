using GX2.DigitalLibrary.DTO.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GX2.DigitalLibrary.Interfaces;
using Microsoft.Extensions.Logging;
using GX2.DigitalLibrary.ViewModel.Models;

namespace GX2.DigitalLibrary.Services.Services
{
    public class AccountService : BaseServices, IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager) : base(configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        public async Task<bool> ValidateAsync(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password,
                 isPersistent: false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task<string> GetUserRoleAsync(string username)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == username);
            var roles = await _userManager.GetRolesAsync(user);
            var rolename = roles.FirstOrDefault();
            return rolename;
        }

        /// <summary>
        /// Register the user in database
        /// </summary>
        /// <returns>Return a message</returns>
        public async Task<bool> RegisterAsync(RegisterViewModel register)
        {

            var user = new ApplicationUser { UserName = register.Username, Email = register.Email, Name = register.Name, PhoneNumber = register.Phone };
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                var applicationRole = await _roleManager.FindByNameAsync(register.Role);
                if (applicationRole != null)
                {
                    await _userManager.AddToRoleAsync(user, applicationRole.Name);
                }

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(RegisterViewModel register)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == register.Username);
            var checkRole = await _userManager.IsInRoleAsync(user, register.Role);
            if (!checkRole)
            {
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
                await _userManager.AddToRoleAsync(user, register.Role);
            }
            user.Email = register.Email;
            user.Name = register.Name;
            user.PhoneNumber = register.Phone;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, register.Password);

            return (await _userManager.UpdateAsync(user)).Succeeded;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            return (await _userManager.DeleteAsync(user)).Succeeded;
        }
    }
}
