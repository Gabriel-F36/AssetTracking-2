﻿// <auto-generated />
using AssetTracking_2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssetTracking_2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231124111221_updatingApplianceName")]
    partial class updatingApplianceName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssetTracking_2.LaptopComputers", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("applianceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("purchaseDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("screenSizeInches")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Laptops");

                    b.HasData(
                        new
                        {
                            id = 1,
                            applianceName = "Laptop Computer",
                            brand = "MacBook (USD)",
                            modelName = "Air",
                            price = 1300,
                            purchaseDate = "2023-09-24",
                            screenSizeInches = 15
                        },
                        new
                        {
                            id = 2,
                            applianceName = "Laptop Computer",
                            brand = "Asus (SEK)",
                            modelName = "Zenbook S 13",
                            price = 15000,
                            purchaseDate = "2023-07-24",
                            screenSizeInches = 13
                        },
                        new
                        {
                            id = 3,
                            applianceName = "Laptop Computer",
                            brand = "Lenovo (SEK)",
                            modelName = "ThinkPad T14s Gen 3",
                            price = 18000,
                            purchaseDate = "2023-04-24",
                            screenSizeInches = 14
                        });
                });

            modelBuilder.Entity("AssetTracking_2.MobilePhones", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("applianceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("purchaseDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("screenSizeInches")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Phones");

                    b.HasData(
                        new
                        {
                            id = 1,
                            applianceName = "Mobile Phone",
                            brand = "iPhone (USD)",
                            modelName = "14",
                            price = 700,
                            purchaseDate = "2023-09-12",
                            screenSizeInches = 6
                        },
                        new
                        {
                            id = 2,
                            applianceName = "Mobile Phone",
                            brand = "Samsung (USD)",
                            modelName = "Galaxy S23",
                            price = 860,
                            purchaseDate = "2023-07-12",
                            screenSizeInches = 7
                        },
                        new
                        {
                            id = 3,
                            applianceName = "Mobile Phone",
                            brand = "Nokia (SEK)",
                            modelName = "G100",
                            price = 1000,
                            purchaseDate = "2023-04-12",
                            screenSizeInches = 7
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
