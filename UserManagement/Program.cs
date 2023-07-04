using Microsoft.EntityFrameworkCore;
using UserManagement.Models;
using UserManagement.Services;

namespace UserManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            IConfiguration c = configurationBuilder
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                                .AddEnvironmentVariables()
                                .Build();

            ConfigSetting configSetting = c.GetRequiredSection("ConfigSetting").Get<ConfigSetting>();

            var builder = WebApplication.CreateBuilder(args);
            Console.WriteLine($"----> Running on {configSetting.KeyThree.ConnectionString}");
            Console.WriteLine($"----> Status Check on {configSetting.KeyOne}");
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configSetting.KeyThree.ConnectionString));

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            DataSeed.GenerateData(app);
            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}