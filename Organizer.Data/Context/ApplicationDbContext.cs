using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Organizer.Data.Mappings;
using Organizer.Domain.Models;


namespace Organizer.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IHostingEnvironment _env;
        public ApplicationDbContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public DbSet<CityModel> Cities { get; set; }
        public DbSet<CountiesModel> Counties { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityModel>().ToTable("Cities","dbo");
            
            modelBuilder.Entity<CountiesModel>().ToTable("Counties","dbo");

            #region Entity Mapping

            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new CountiesMapping());

            #endregion
            


            base.OnModelCreating(modelBuilder);
        }
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile($"appsettings.json")
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true)
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
             optionsBuilder.EnableDetailedErrors();
             optionsBuilder.EnableSensitiveDataLogging();
         }
    }
}