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
    [Migration("20231120095600_StartingDatabase")]
    partial class StartingDatabase
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
                });

            modelBuilder.Entity("AssetTracking_2.MobilePhones", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

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
                });
#pragma warning restore 612, 618
        }
    }
}