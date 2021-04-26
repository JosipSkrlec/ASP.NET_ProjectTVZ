using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vjezba.Model;

namespace Vjezba.DAL
{
    public class ThreeDModelDbContext : IdentityDbContext<AppUser>
    {
        public ThreeDModelDbContext(DbContextOptions<ThreeDModelDbContext> options)
            : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(new City { ID = 1, Name = "Zagreb" });
            modelBuilder.Entity<City>().HasData(new City { ID = 2, Name = "Velika Gorica" });
            modelBuilder.Entity<City>().HasData(new City { ID = 3, Name = "Vrbovsko" });
            modelBuilder.Entity<Client>().HasData(new Client { ID = 1, FirstName = "Marko", LastName = "Markic", Email= "mmarkic@index.hr", CityID = 1});
            modelBuilder.Entity<Client>().HasData(new Client { ID = 2, FirstName = "Ana", LastName = "Anic", Email = "aanic@yahoo.com", CityID = 2});
        }

    }
}
