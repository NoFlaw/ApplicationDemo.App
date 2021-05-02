﻿// <auto-generated />
using System;
using ApplicationDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApplicationDemo.Data.Migrations
{
    [DbContext(typeof(AppDemoContext))]
    [Migration("20210426070019_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationDemo.Data.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Contact");

                    b.HasData(
                        new
                        {
                            Id = new Guid("da77f1c5-085a-4c12-a468-521e14665e15"),
                            EmailAddress = "BrentonBates@gmail.com",
                            Name = "Brenton Bates"
                        },
                        new
                        {
                            Id = new Guid("6ee3c349-57e0-4894-aadc-898f39607097"),
                            EmailAddress = "SeanLivingston@gmail.com",
                            Name = "Sean Livingston"
                        },
                        new
                        {
                            Id = new Guid("5da56949-03ae-4f9a-9632-204c6db5638f"),
                            EmailAddress = "StephonJohnson@gmail.com",
                            Name = "Stephon Johnson"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
