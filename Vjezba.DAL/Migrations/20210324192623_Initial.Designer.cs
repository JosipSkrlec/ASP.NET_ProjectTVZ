﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vjezba.DAL;

namespace Vjezba.DAL.Migrations
{
    [DbContext(typeof(ClientManagerDbContext))]
    [Migration("20210324192623_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vjezba.Model.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cityes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Zagreb"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Split"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Rijeka"
                        });
                });

            modelBuilder.Entity("Vjezba.Model.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Vjezba.Model.Meeting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cancelled")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scheduled")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoCall")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VideoCallEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VideoCallStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("Vjezba.Model.Client", b =>
                {
                    b.HasOne("Vjezba.Model.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID");

                    b.Navigation("City");
                });
#pragma warning restore 612, 618
        }
    }
}
