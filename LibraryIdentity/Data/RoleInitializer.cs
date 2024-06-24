using LibraryIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryIdentity.Data
{
    public class RoleInitializer
    {
        public static async Task Seed(AuthDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                var roleUser = new IdentityRole
                {
                    Name = "user",
                    NormalizedName = "user"
                };
                await roleManager.CreateAsync(roleAdmin);
                await roleManager.CreateAsync(roleUser);

            }
            if (!context.Users.Any())
            {
                var user = new AppUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                var result = await userManager.CreateAsync(user, "%12Aaa3456");
                var admin = new AppUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "%12Aaa3456");
                var tempadmin = await userManager.Users.FirstOrDefaultAsync(u => u.Email == "admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
                await userManager.AddToRoleAsync(user, "user");
                await context.SaveChangesAsync();
            }
        }
    }
}
