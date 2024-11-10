using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using personBeheerSysteem.Data;
using System;
using System.Windows;

namespace personBeheerSysteem
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            InitializeComponent();
            var services = new ServiceCollection();

            // Configure DbContext
            services.AddDbContext<PersonenDbContext>(options =>
                options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonenDbDev;Integrated Security=True;"));

            // Add Identity services
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3; // Allow simple password for testing
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<PersonenDbContext>()
            .AddDefaultTokenProviders();

            // Add logging services (required for UserManager and SignInManager)
            services.AddLogging();

            // Build the service provider
            ServiceProvider = services.BuildServiceProvider();

            // Initialize the database (create it if it doesn't exist)
            using (var scope = ServiceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PersonenDbContext>();
                dbContext.Database.EnsureCreated(); // Ensures that the database and Identity tables are created

                
                // Seed dummy users (TEMPORARY, REMOVE OR COMMENT OUT AFTER RUNNING ONCE)
                UserSeeder.SeedDummyUsers(scope.ServiceProvider).Wait();

            }
        }
    }
}
