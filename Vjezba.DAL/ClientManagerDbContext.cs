using Microsoft.EntityFrameworkCore;
using Vjezba.Model;

namespace Vjezba.DAL
{
    // Zadatak 7.2.A
    public class ClientManagerDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        protected ClientManagerDbContext() { }
        public ClientManagerDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }

        public DbSet<City> Cityes { get; set; }

        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().HasData(new City { ID = 1, Name = "Zagreb" });
            modelBuilder.Entity<City>().HasData(new City { ID = 2, Name = "Split" });
            modelBuilder.Entity<City>().HasData(new City { ID = 3, Name = "Rijeka" });

            //modelBuilder.Entity<Client>(b =>
            //{
            //    b.HasData(new Client
            //    {
            //        ID = 35,
            //        FirstName = "Josip",
            //        LastName = "Škrlec",
            //        Email = "jskrlec1997@gmail.com",
            //        Gender = 'g',
            //        Address = "Zagreb, Vrbik,3",
            //        PhoneNumber = "0998353200",
                    
            //    });
            //    //b.OwnsOne(e => e.City).HasData(new City
            //    //{
            //    //    ID = 1,
            //    //    Name = "Zagreb"
            //    //}) ;
            //    b.HasData(new City
            //    {
            //        ID = 1,
            //        Name = "Zagreb"
            //    });
            //});

            //modelBuilder.Entity<Client>().HasData(new Client
            //{
            //    ID = 35,
            //    FirstName = "Josip",
            //    LastName = "Škrlec",
            //    Email = "jskrlec1997@gmail.com",
            //    Gender = 'M',
            //    Address = "Zagreb, Vrbik,3",
            //    PhoneNumber = "0998353200",

            //});


        }




    }
}