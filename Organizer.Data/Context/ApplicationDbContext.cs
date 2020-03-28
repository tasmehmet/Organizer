using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Organizer.Data.Mappings;
using Organizer.Domain.Models;


namespace Organizer.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<CityModel> Cities { get; set; }
        public DbSet<CountiesModel> Counties { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityModel>().ToTable("Cities","dbo");

            modelBuilder.Entity<CmsEntity>().HasKey(p => new {p.ID, p.Lang});

            modelBuilder.Entity<CountiesModel>().ToTable("Counties","dbo").HasKey(p => new {p.ID});

            #region Entity Mapping

            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new CountiesMapping());

            #endregion
            


            base.OnModelCreating(modelBuilder);
        }
    }
}