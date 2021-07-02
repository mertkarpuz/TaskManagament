using Microsoft.AspNetCore.Identity;
using Navyki.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navyki.ToDo.Web
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }
            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("mert");
            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    Name = "Mert",
                    Surname = "Karpuz",
                    UserName = "mert",
                    Email = "m.mertt@hotmail.com"
                };
                await userManager.CreateAsync(user,"1");
                await userManager.AddToRoleAsync(user, "Admin");
            }

        }
    }
}
