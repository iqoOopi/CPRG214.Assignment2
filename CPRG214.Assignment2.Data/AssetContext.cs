using CPRG214.Assignment2.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CPRG214.Assignment2.Data
{
        public class AssetContext : DbContext
        {
            public AssetContext() : base() { }

            public DbSet<Asset> Assets { get; set; }
            public DbSet<AssetType> AssetTypes { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                //Change the connection string here for your home computer/lab computer
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;
                                          Database=AssetsDB;
                                          Trusted_Connection=True;");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

        //seed data created here
        //Computer manufacturers: Dell, HP, Acer
        //Monitors: Acer, LG, HP
        //Phone: Avaya, Polycom, Cisco
                modelBuilder.Entity<AssetType>().HasData(
                    new AssetType { Id = 1, Name = "Computer" },
                    new AssetType { Id = 2, Name = "Monitors" },
                    new AssetType { Id = 3, Name = "Phone" }
                    );

                modelBuilder.Entity<Asset>().HasData(
                        new Asset
                        {
                            Id = 1,
                            TagNumber = "CompuTest01",
                            AssetTypeId = 1,
                            Manufacturer ="Dell",
                            Model="Ispell",
                            Description="this is computertest",
                            SerialNumber="001002"
                        },
                        new Asset
                        {
                            Id = 2,
                            TagNumber = "MonitorTest01",
                            AssetTypeId = 2,
                            Manufacturer = "HP",
                            Model = "HP1",
                            Description = "this is Monitor Test",
                            SerialNumber = "002001"
                        },
                        new Asset
                        {
                            Id = 3,
                            TagNumber = "PhoneTest01",
                            AssetTypeId = 3,
                            Manufacturer = "Cisco",
                            Model = "Cisco01",
                            Description = "this is Phone Test",
                            SerialNumber = "003001"
                        }

                    );

                
            }
        }
}
