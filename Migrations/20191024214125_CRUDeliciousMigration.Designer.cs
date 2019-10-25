﻿// <auto-generated />
using System;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRUDelicious.Migrations
{
    [DbContext(typeof(CruddyContext))]
    [Migration("20191024214125_CRUDeliciousMigration")]
    partial class CRUDeliciousMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CRUDelicious.Models.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Calories");

                    b.Property<string>("ChefName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("Tastiness");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("DishId");

                    b.ToTable("Dishes");
                });
#pragma warning restore 612, 618
        }
    }
}
