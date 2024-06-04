using Microsoft.EntityFrameworkCore;
using MyVaccineWebApi.Literals;
using MyVaccineWebApi.Models;
using System.Runtime.CompilerServices;

namespace MyVaccineWebApi.Configurations
{
    public static class DbConfigurations
    {
        public  static IServiceCollection SetDatabaseConfiguration(this IServiceCollection services)
        {
            //var connetionString = Environment.GetEnvironmentVariable(MyVaccineLiterals.CONNECTION_STRING);
            var connetionString = "Server=localhost,1433;Database=MyVaccine;User Id=sa;Password=1991;TrustServerCertificate=True;";
            services.AddDbContext<MyVaccineAppDbContext>(options =>
              options.UseSqlServer (
                  connetionString
                  )
              );
            return services;
        }
    }
}
