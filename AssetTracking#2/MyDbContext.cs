using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking_2
{
    internal class MyDbContext : DbContext
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AssetTrackingDB;Integrated Security=True";

        public DbSet<LaptopComputers> Laptops { get; set; }
        public DbSet<MobilePhones> Phones { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.Entity<LaptopComputers>().HasData(new LaptopComputers { id = 1, applianceName = "Laptop Computer", brand = "MacBook (USD)", modelName = "Air", purchaseDate = "2021-01-24", screenSizeInches = 15, price = 1300 });
            ModelBuilder.Entity<LaptopComputers>().HasData(new LaptopComputers { id = 2, applianceName = "Laptop Computer", brand = "Asus (SEK)", modelName = "Zenbook S 13", purchaseDate = "2021-04-24", screenSizeInches = 13, price = 15000 });
            ModelBuilder.Entity<LaptopComputers>().HasData(new LaptopComputers { id = 3, applianceName = "Laptop Computer", brand = "Lenovo (SEK)", modelName = "ThinkPad T14s Gen 3", purchaseDate = "2022-04-24", screenSizeInches = 14, price = 18000 });

            ModelBuilder.Entity<MobilePhones>().HasData(new MobilePhones { id = 1, applianceName = "Mobile Phone", brand = "iPhone (USD)", modelName = "14", purchaseDate = "2021-01-12", screenSizeInches = 6, price = 700 });
            ModelBuilder.Entity<MobilePhones>().HasData(new MobilePhones { id = 2, applianceName = "Mobile Phone", brand = "Samsung (USD)", modelName = "Galaxy S23", purchaseDate = "2021-04-12", screenSizeInches = 7, price = 860 });
            ModelBuilder.Entity<MobilePhones>().HasData(new MobilePhones { id = 3, applianceName = "Mobile Phone", brand = "Nokia (SEK)", modelName = "G100", purchaseDate = "2022-04-12", screenSizeInches = 7, price = 1000 });
        }
    }
}

// Migration
// To Open => Tools -> NuGet Package Manager -> Package Manager Console
// - add-migration migration-name // Creates a migration by adding a migration snapshot. ("migration-name" can be used as commit comments)
// - Remove-migration // Removes the last migration snapshot
// - update-database // updates the database schema based on the lastmigration snapshot
// - Script-migration // Generates a SQQL script using all the migration snapshots
