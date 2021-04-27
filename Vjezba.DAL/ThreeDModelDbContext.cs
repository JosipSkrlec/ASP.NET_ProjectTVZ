using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Vjezba.Model;

namespace Vjezba.DAL
{
    public class ThreeDModelDbContext : IdentityDbContext<AppUser>
    {
        public ThreeDModelDbContext(DbContextOptions<ThreeDModelDbContext> options)
            : base(options)
        {

        }

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

            modelBuilder.Entity<OBJAttachment>().HasData(new OBJAttachment { ID = 1, OBJFilePath = "/3DModels/DefaultCube.obj" });
            modelBuilder.Entity<OBJAttachment>().HasData(new OBJAttachment { ID = 2, OBJFilePath = "/3DModels/DefaultCube.obj" });
            modelBuilder.Entity<OBJAttachment>().HasData(new OBJAttachment { ID = 3, OBJFilePath = "/3DModels/DefaultCube.obj" });

            modelBuilder.Entity<ThreeD>().HasData(new ThreeD { ID = 1, Name = "Object1", Comment = "Lorem Ipsum1", UploadedDateTime = DateTime.Now, CreatedBy = "Josip Skrlec1", CategoryID = 1,objAttachmentID = 3 });
            modelBuilder.Entity<ThreeD>().HasData(new ThreeD { ID = 2, Name = "Object2", Comment = "Lorem Ipsum2", UploadedDateTime = DateTime.Now, CreatedBy = "Josip Skrlec2", CategoryID = 3,objAttachmentID = 2 });
            modelBuilder.Entity<ThreeD>().HasData(new ThreeD { ID = 3, Name = "Object3", Comment = "Lorem Ipsum3", UploadedDateTime = DateTime.Now, CreatedBy = "Josip Skrlec3", CategoryID = 2,objAttachmentID = 1 });

            
        }
    }
}
