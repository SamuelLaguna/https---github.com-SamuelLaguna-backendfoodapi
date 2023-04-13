﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backendfoodapi.Services.Context;

#nullable disable

namespace backendfoodapi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("backendfoodapi.Models.IngredientItemModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("Calories")
                        .HasColumnType("int");

                    b.Property<int?>("Carbs")
                        .HasColumnType("int");

                    b.Property<int?>("Fat")
                        .HasColumnType("int");

                    b.Property<string>("IngredientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Protien")
                        .HasColumnType("int");

                    b.Property<int?>("Sodium")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("IngredientInfo");
                });

            modelBuilder.Entity("backendfoodapi.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
