﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Siteware.Data;

namespace Siteware.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200920040108_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Siteware.Models.Cart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            id = 1
                        });
                });

            modelBuilder.Entity("Siteware.Models.CartItems", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cartId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("cartId");

                    b.HasIndex("productId");

                    b.ToTable("CartItems");

                    b.HasData(
                        new
                        {
                            id = 1,
                            cartId = 1,
                            productId = 2,
                            quantity = 1
                        },
                        new
                        {
                            id = 2,
                            cartId = 1,
                            productId = 4,
                            quantity = 2
                        },
                        new
                        {
                            id = 3,
                            cartId = 1,
                            productId = 3,
                            quantity = 3
                        },
                        new
                        {
                            id = 4,
                            cartId = 1,
                            productId = 1,
                            quantity = 5
                        });
                });

            modelBuilder.Entity("Siteware.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("price")
                        .HasColumnType("double");

                    b.Property<int>("saletype")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Fender Jazzmaster",
                            price = 230.0,
                            saletype = 1
                        },
                        new
                        {
                            id = 2,
                            name = "Fender Stratocaster",
                            price = 150.0,
                            saletype = 1
                        },
                        new
                        {
                            id = 3,
                            name = "Ibanez JEM",
                            price = 400.0,
                            saletype = 2
                        },
                        new
                        {
                            id = 4,
                            name = "Gibson SG",
                            price = 250.0,
                            saletype = 0
                        },
                        new
                        {
                            id = 5,
                            name = "Gibson Explorer",
                            price = 500.0,
                            saletype = 0
                        });
                });

            modelBuilder.Entity("Siteware.Models.CartItems", b =>
                {
                    b.HasOne("Siteware.Models.Cart", "cart")
                        .WithMany("cartItems")
                        .HasForeignKey("cartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Siteware.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}