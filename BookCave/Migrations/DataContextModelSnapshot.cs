﻿// <auto-generated />
using BookCave.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BookCave.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookCave.Models.EntityModels.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Image");

                    b.Property<string>("Password");

                    b.Property<int?>("ShippingId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("ShippingId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<int>("Discount");

                    b.Property<string>("Image");

                    b.Property<int>("Pages");

                    b.Property<double>("Price");

                    b.Property<string>("Publisher");

                    b.Property<double>("Rating");

                    b.Property<string>("Title");

                    b.Property<int>("YearPublished");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.BookIdItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<int?>("AccountId1");

                    b.Property<int?>("AccountId2");

                    b.Property<int>("AuthorId");

                    b.Property<int>("BookId");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AccountId1");

                    b.HasIndex("AccountId2");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("BookIdItem");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("Quantity");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.CategoryIdItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<int>("CategoryId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("CategoryIdItem");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<string>("BookComment");

                    b.Property<int>("BookId");

                    b.Property<double>("Rating");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CartId");

                    b.Property<int?>("ShippingId");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ShippingId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.LanguageItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BookId");

                    b.Property<string>("Language");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("LanguageItem");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("PaidDate");

                    b.Property<int>("ShippingInfoId");

                    b.Property<string>("Status");

                    b.Property<double>("Total");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountId");

                    b.Property<int>("AuthorId");

                    b.Property<int>("BookId");

                    b.Property<int>("OrderId");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.ShippingInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int>("PostalCode");

                    b.Property<string>("SendingMethod");

                    b.Property<string>("Street");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ShippingInfo");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Account", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.ShippingInfo", "Shipping")
                        .WithMany()
                        .HasForeignKey("ShippingId");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.BookIdItem", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Account")
                        .WithMany("Cart")
                        .HasForeignKey("AccountId");

                    b.HasOne("BookCave.Models.EntityModels.Account")
                        .WithMany("FavoriteBooks")
                        .HasForeignKey("AccountId1");

                    b.HasOne("BookCave.Models.EntityModels.Account")
                        .WithMany("WishList")
                        .HasForeignKey("AccountId2");

                    b.HasOne("BookCave.Models.EntityModels.Author")
                        .WithMany("BookIdList")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookCave.Models.EntityModels.Book")
                        .WithMany("AuthorBookIdList")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.CategoryIdItem", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Book")
                        .WithMany("CategoryIdList")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Customer", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.OrderItem", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.HasOne("BookCave.Models.EntityModels.ShippingInfo", "Shipping")
                        .WithMany()
                        .HasForeignKey("ShippingId");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.LanguageItem", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Book")
                        .WithMany("LanguageList")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.OrderItem", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Account")
                        .WithMany("History")
                        .HasForeignKey("AccountId");

                    b.HasOne("BookCave.Models.EntityModels.Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
