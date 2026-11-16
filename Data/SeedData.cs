using Holistic_Hiking.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Holistic_Hiking.Data;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        const string email = "test@example.com";
        if (await userManager.FindByEmailAsync(email) == null)
        {
            var testUser = new User
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                FirstName = "firstName",
                LastName = "lastName",
                UserBio = "A short bio"
            };
            var result = await userManager.CreateAsync(testUser, "Passw0rd!");
            if (!result.Succeeded)
            {
                throw new InvalidOperationException(string.Join("; ", result.Errors.Select(e => e.Description)));
            }

        }
    }
}