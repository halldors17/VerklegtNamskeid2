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
    [Migration("20180504114402_categoriesTable_added")]
    partial class categoriesTable_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookCave.Models.EntityModels.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.AuthorIdItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<int?>("BookId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorIdItem");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Audio");

                    b.Property<string>("Description");

                    b.Property<bool>("Ebook");

                    b.Property<int>("Minutes");

                    b.Property<int>("Pages");

                    b.Property<bool>("Paperback");

                    b.Property<int>("Price");

                    b.Property<string>("Publisher");

                    b.Property<int>("Stock");

                    b.Property<string>("Title");

                    b.Property<int>("YearPublished");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.BookIdItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorId");

                    b.Property<int>("BookId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookIdItem");
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

                    b.Property<int?>("BookId");

                    b.Property<int>("CategoryId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("CategoryIdItem");
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

                    b.Property<string>("language");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("LanguageItem");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.AuthorIdItem", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Book")
                        .WithMany("AuthorIdList")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.BookIdItem", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Author")
                        .WithMany("BookIdList")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.CategoryIdItem", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Book")
                        .WithMany("CategoryIdList")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("BookCave.Models.EntityModels.LanguageItem", b =>
                {
                    b.HasOne("BookCave.Models.EntityModels.Book")
                        .WithMany("LanguageList")
                        .HasForeignKey("BookId");
                });
#pragma warning restore 612, 618
        }
    }
}
