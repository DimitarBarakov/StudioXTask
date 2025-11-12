using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudioXFirstTask.Models;

namespace StudioXFirstTask.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Country>().HasData(
               new Country() { Id = 1, Name = "Bulgaria"},
               new Country() { Id = 2, Name = "Germany" },
               new Country() { Id = 3, Name = "England" }
            );
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
