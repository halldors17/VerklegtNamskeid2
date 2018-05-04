using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class bookTable_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Employees",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Employees",
                newName: "Password");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Audio = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Ebook = table.Column<bool>(nullable: false),
                    Minutes = table.Column<int>(nullable: false),
                    Pages = table.Column<int>(nullable: false),
                    Paperback = table.Column<bool>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Publisher = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    YearPublished = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorIdItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorIdItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorIdItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryIdItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryIdItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryIdItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LanguageItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: true),
                    language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorIdItem_BookId",
                table: "AuthorIdItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryIdItem_BookId",
                table: "CategoryIdItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageItem_BookId",
                table: "LanguageItem",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorIdItem");

            migrationBuilder.DropTable(
                name: "CategoryIdItem");

            migrationBuilder.DropTable(
                name: "LanguageItem");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Employees",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Employees",
                newName: "password");
        }
    }
}
