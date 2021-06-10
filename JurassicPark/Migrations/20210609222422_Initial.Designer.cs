﻿// <auto-generated />
using JurassicPark.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JurassicPark.Migrations
{
    [DbContext(typeof(JurassicParkContext))]
    [Migration("20210609222422_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("JurassicPark.Models.Dinosaur", b =>
                {
                    b.Property<int>("DinosaurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Species")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("DinosaurId");

                    b.ToTable("Dinosaurs");
                });
#pragma warning restore 612, 618
        }
    }
}
