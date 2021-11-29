using GX2.DigitalLibrary.DTO.Models;
using GX2.DigitalLibrary.Interfaces;
using GX2.DigitalLibrary.ViewModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GX2.DigitalLibrary.Helper
{
    public static class GenericHelper
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var accountService = serviceProvider.GetRequiredService<IAccountService>();

            string[] rolesNames = { "Admin", "User" };
            IdentityResult result;
            foreach (var namesRole in rolesNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(namesRole);
                if (!roleExist)
                {
                    result = await roleManager.CreateAsync(new IdentityRole(namesRole));
                    RegisterViewModel register = new()
                    {
                        Username = "gcm10000",
                        Password = "SenhaSecreta#2021",
                        Email = "gcm10000@admin.com",
                        Role = rolesNames[0],
                        Name = "Gabriel Machado",
                        Phone = "1140028922"
                    };

                    await accountService.RegisterAsync(register);
                }
            }
        }
    }
}
