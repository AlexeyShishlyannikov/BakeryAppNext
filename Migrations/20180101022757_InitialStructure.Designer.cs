﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NextSugarCat.Persistance;
using System;

namespace NextSugarCat.Migrations
{
    [DbContext(typeof(BakeryDbContext))]
    [Migration("20180101022757_InitialStructure")]
    partial class InitialStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NextSugarCat.Core.Models.Cake", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MenuItemId1");

                    b.Property<int>("PricePerPound");

                    b.HasKey("MenuItemId");

                    b.HasIndex("MenuItemId1");

                    b.ToTable("Cakes");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.Contacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Facebook");

                    b.Property<string>("Google");

                    b.Property<string>("Instagram");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.Cupcake", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MenuItemId1");

                    b.Property<int>("Price12pc");

                    b.Property<int>("Price24pc");

                    b.Property<int>("Price6pc");

                    b.HasKey("MenuItemId");

                    b.HasIndex("MenuItemId1");

                    b.ToTable("Cupcakes");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.Macaroon", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MenuItemId1");

                    b.Property<int>("PricePer12pc");

                    b.Property<int>("PricePer1pc");

                    b.Property<int>("PricePer3pc");

                    b.Property<int>("PricePer6pc");

                    b.HasKey("MenuItemId");

                    b.HasIndex("MenuItemId1");

                    b.ToTable("Macaroons");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.MenuItemIngredient", b =>
                {
                    b.Property<int>("MenuItemId");

                    b.Property<int>("IngredientId");

                    b.Property<int?>("Amount");

                    b.HasKey("MenuItemId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("MenuItemIngredients");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName");

                    b.Property<int>("MenuItemId");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.Cake", b =>
                {
                    b.HasOne("NextSugarCat.Core.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId1");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.Cupcake", b =>
                {
                    b.HasOne("NextSugarCat.Core.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId1");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.Macaroon", b =>
                {
                    b.HasOne("NextSugarCat.Core.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId1");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.MenuItemIngredient", b =>
                {
                    b.HasOne("NextSugarCat.Core.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NextSugarCat.Core.Models.MenuItem", "MenuItem")
                        .WithMany("Ingredients")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.Photo", b =>
                {
                    b.HasOne("NextSugarCat.Core.Models.MenuItem")
                        .WithMany("Photos")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
