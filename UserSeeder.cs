using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace personBeheerSysteem.Data
{
    public static class UserSeeder
    {
        public static async Task SeedDummyUsers(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var dummyUsers = new[]
            {
                new { Username = "test123", Password = "123456" },
                new { Username = "test1234", Password = "123456" },
                new { Username = "test12345", Password = "123456" }
            };

            foreach (var user in dummyUsers)
            {
                if (await userManager.FindByNameAsync(user.Username) == null)
                {
                    var identityUser = new IdentityUser { UserName = user.Username, Email = $"{user.Username}@example.com" };
                    var result = await userManager.CreateAsync(identityUser, user.Password);

                    if (!result.Succeeded)
                    {
                        // Log or print out errors, if any
                        Console.WriteLine($"Failed to create user {user.Username}: {string.Join(", ", result.Errors)}");
                    }
                }
            }
        }
    }
}
