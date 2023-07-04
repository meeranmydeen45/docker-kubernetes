using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Services
{
    public static class DataSeed
    {
        public static void GenerateData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                PopulateData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>());
            }
        }

        private static void PopulateData(AppDbContext context)
        {
            try
            {
                Console.WriteLine($"---> Migration Started");
                context.Database.Migrate();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"---> Error Occured During Migration {ex.Message}");
            }


            if (!context.Users.Any())
            {
                Console.WriteLine($"---> Data Seeding Started");
                List<User> users = new List<User>
                {
                    new User { UserName = "Bill Gates", Address = "New York"},
                     new User { UserName = "Steve", Address = "California"},
                     new User { UserName = "Ellen", Address = "Chicago"},
                };
                context.Users.AddRange(users);
                context.SaveChanges();
            }
            
        }
    }
}
