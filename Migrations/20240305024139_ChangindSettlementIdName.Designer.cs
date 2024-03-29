﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoutesManagementSystem.API.DbContexts;

#nullable disable

namespace RoutesManagementSystem.API.Migrations
{
    [DbContext(typeof(RoutesManagerDbContext))]
    [Migration("20240305024139_ChangindSettlementIdName")]
    partial class ChangindSettlementIdName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RoutesManagementSystem.API.Entities.LastMileRoute", b =>
                {
                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("ConfigurationType")
                        .HasColumnType("int");

                    b.Property<int>("DaysForDelivery")
                        .HasColumnType("int");

                    b.Property<int>("Identify")
                        .HasColumnType("int");

                    b.Property<int>("MaximumLoads")
                        .HasColumnType("int");

                    b.Property<int>("MinimumLoads")
                        .HasColumnType("int");

                    b.HasKey("RouteId");

                    b.ToTable("LastMileRoutes");
                });

            modelBuilder.Entity("RoutesManagementSystem.API.Entities.MiddleMileRoute", b =>
                {
                    b.Property<int>("RoputeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoputeId"));

                    b.Property<int>("DeliveryTime")
                        .HasColumnType("int");

                    b.Property<string>("DestinationBusinessUnit")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int?>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("RoputeId");

                    b.HasIndex("RouteId")
                        .IsUnique()
                        .HasFilter("[RouteId] IS NOT NULL");

                    b.ToTable("MiddleMileRoutes");
                });

            modelBuilder.Entity("RoutesManagementSystem.API.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BusinessUnit")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.Property<int>("RouteTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RouteTypeId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("RoutesManagementSystem.API.Entities.RouteType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("RouteTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Entrega mismo dia",
                            Name = "EMD"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Ruta articulos chicos",
                            Name = "RAC"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Mudancitas",
                            Name = "Normal"
                        });
                });

            modelBuilder.Entity("RoutesManagementSystem.API.Entities.Settlement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Settlements");
                });

            modelBuilder.Entity("RoutesManagementSystem.API.Entities.LastMileRoute", b =>
                {
                    b.HasOne("RoutesManagementSystem.API.Entities.Route", "Route")
                        .WithOne("LastMileRoute")
                        .HasForeignKey("RoutesManagementSystem.API.Entities.LastMileRoute", "RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("RoutesManagementSystem.API.Entities.MiddleMileRoute", b =>
                {
                    b.HasOne("RoutesManagementSystem.API.Entities.Route", "Route")
                        .WithOne("MiddleMileRoute")
                        .HasForeignKey("RoutesManagementSystem.API.Entities.MiddleMileRoute", "RouteId");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("RoutesManagementSystem.API.Entities.Route", b =>
                {
                    b.HasOne("RoutesManagementSystem.API.Entities.RouteType", "RouteType")
                        .WithMany()
                        .HasForeignKey("RouteTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteType");
                });

            modelBuilder.Entity("RoutesManagementSystem.API.Entities.Route", b =>
                {
                    b.Navigation("LastMileRoute");

                    b.Navigation("MiddleMileRoute");
                });
#pragma warning restore 612, 618
        }
    }
}
