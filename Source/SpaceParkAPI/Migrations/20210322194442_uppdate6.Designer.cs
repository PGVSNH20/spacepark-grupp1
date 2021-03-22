﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceParkAPI.DbContextModels;

namespace SpaceParkAPI.Migrations
{
    [DbContext(typeof(SpaceParkDbContext))]
    [Migration("20210322194442_uppdate6")]
    partial class uppdate6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpaceParkAPI.DbContextModels.ParkingRegistration", b =>
                {
                    b.Property<Guid>("ParkingRegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("bit");

                    b.Property<decimal>("ParkingFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ParkingSpotId")
                        .HasColumnType("int");

                    b.Property<int>("StarshipId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ParkingRegistrationId");

                    b.HasIndex("ParkingSpotId");

                    b.HasIndex("UserId");

                    b.ToTable("ParkingRegistrations");
                });

            modelBuilder.Entity("SpaceParkAPI.DbContextModels.ParkingSpot", b =>
                {
                    b.Property<int>("ParkingSpotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("bit");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("ParkingSpotId");

                    b.ToTable("ParkingSpots");
                });

            modelBuilder.Entity("SpaceParkAPI.DbContextModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SpaceParkAPI.DbContextModels.ParkingRegistration", b =>
                {
                    b.HasOne("SpaceParkAPI.DbContextModels.ParkingSpot", "ParkingSpot")
                        .WithMany()
                        .HasForeignKey("ParkingSpotId");

                    b.HasOne("SpaceParkAPI.DbContextModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("ParkingSpot");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
