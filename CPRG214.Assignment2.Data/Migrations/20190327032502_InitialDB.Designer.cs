﻿// <auto-generated />
using CPRG214.Assignment2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CPRG214.Assignment2.Data.Migrations
{
    [DbContext(typeof(AssetContext))]
    [Migration("20190327032502_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CPRG214.Assignment2.Domain.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssetTypeId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Manufacturer")
                        .IsRequired();

                    b.Property<string>("Model");

                    b.Property<string>("SerialNumber")
                        .IsRequired();

                    b.Property<string>("TagNumber")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.ToTable("Assets");

                    b.HasData(
                        new { Id = 1, AssetTypeId = 1, Description = "this is computertest", Manufacturer = "Dell", Model = "Ispell", SerialNumber = "001002", TagNumber = "CompuTest01" },
                        new { Id = 2, AssetTypeId = 2, Description = "this is Monitor Test", Manufacturer = "HP", Model = "HP1", SerialNumber = "002001", TagNumber = "MonitorTest01" },
                        new { Id = 3, AssetTypeId = 3, Description = "this is Phone Test", Manufacturer = "Cisco", Model = "Cisco01", SerialNumber = "003001", TagNumber = "PhoneTest01" }
                    );
                });

            modelBuilder.Entity("CPRG214.Assignment2.Domain.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AssetTypes");

                    b.HasData(
                        new { Id = 1, Name = "Computer" },
                        new { Id = 2, Name = "Monitors" },
                        new { Id = 3, Name = "Phone" }
                    );
                });

            modelBuilder.Entity("CPRG214.Assignment2.Domain.Asset", b =>
                {
                    b.HasOne("CPRG214.Assignment2.Domain.AssetType")
                        .WithMany("Assets")
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
