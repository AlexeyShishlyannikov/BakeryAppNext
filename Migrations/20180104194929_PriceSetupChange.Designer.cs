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
    [Migration("20180104194929_PriceSetupChange")]
    partial class PriceSetupChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("NextSugarCat.Core.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.ItemPricePerSet", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MenuItemPriceId");

                    b.Property<int>("SetPrice");

                    b.Property<int>("SetSize");

                    b.HasKey("MenuItemId");

                    b.HasIndex("MenuItemPriceId");

                    b.ToTable("SetPrices");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("MinimumWeight");

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

                    b.HasKey("MenuItemId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("MenuItemIngredients");
                });

            modelBuilder.Entity("NextSugarCat.Core.Models.MenuItemPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CakePricePerPound");

                    b.Property<int>("MenuItemId");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId")
                        .IsUnique();

                    b.ToTable("MenuItemPrices");
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

            modelBuilder.Entity("NextSugarCat.Core.Models.ItemPricePerSet", b =>
                {
                    b.HasOne("NextSugarCat.Core.Models.MenuItemPrice")
                        .WithMany("PricePerSet")
                        .HasForeignKey("MenuItemPriceId");
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

            modelBuilder.Entity("NextSugarCat.Core.Models.MenuItemPrice", b =>
                {
                    b.HasOne("NextSugarCat.Core.Models.MenuItem")
                        .WithOne("Price")
                        .HasForeignKey("NextSugarCat.Core.Models.MenuItemPrice", "MenuItemId")
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
