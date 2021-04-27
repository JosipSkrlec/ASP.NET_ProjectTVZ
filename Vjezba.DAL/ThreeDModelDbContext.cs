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

        //modelBuilder.Entity<City>().HasData(new City { ID = 1, Name = "Varazdin" });
        //modelBuilder.Entity<City>().HasData(new City { ID = 2, Name = "Zagreb" });

        //modelBuilder.Entity<Client>().HasData(new Client { ID = 1, FirstName = "Marko", LastName = "Markic", Email = "mmarkic@index.hr", CityID = 1 });
        //modelBuilder.Entity<Client>().HasData(new Client { ID = 2, FirstName = "Ana", LastName = "Anic", Email = "aanic@yahoo.com", CityID = 2 });

        public DbSet<ThreeD> threeD { get; set; }
        public DbSet<ThreeDCategory> threeDCategoryes { get; set; }
        public DbSet<OBJAttachment> ThreeDAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ThreeDCategory>().HasData(new ThreeDCategory { ID = 1, Name = "Game ready" });
            modelBuilder.Entity<ThreeDCategory>().HasData(new ThreeDCategory { ID = 2, Name = "Render ready" });
            modelBuilder.Entity<ThreeDCategory>().HasData(new ThreeDCategory { ID = 3, Name = "Low poly" });
            modelBuilder.Entity<ThreeDCategory>().HasData(new ThreeDCategory { ID = 4, Name = "High poly" });

        }

    }
}
