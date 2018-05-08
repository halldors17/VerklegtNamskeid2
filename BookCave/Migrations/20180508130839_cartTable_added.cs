using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class cartTable_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIdItem_Authors_AuthorId",
                table: "BookIdItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryIdItem_Books_BookId",
                table: "CategoryIdItem");

            migrationBuilder.DropTable(
                name: "AuthorIdItem");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Orders",
                newName: "Total");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShippingInfo",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "CategoryIdItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Books",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "BookIdItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Authors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    CartId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookIdItem_BookId",
                table: "BookIdItem",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIdItem_Authors_AuthorId",
                table: "BookIdItem",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookIdItem_Books_BookId",
                table: "BookIdItem",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryIdItem_Books_BookId",
                table: "CategoryIdItem",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIdItem_Authors_AuthorId",
                table: "BookIdItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BookIdItem_Books_BookId",
                table: "BookIdItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryIdItem_Books_BookId",
                table: "CategoryIdItem");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_BookIdItem_BookId",
                table: "BookIdItem");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShippingInfo");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Orders",
                newName: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "CategoryIdItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "BookIdItem",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.CreateIndex(
                name: "IX_AuthorIdItem_BookId",
                table: "AuthorIdItem",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIdItem_Authors_AuthorId",
                table: "BookIdItem",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryIdItem_Books_BookId",
                table: "CategoryIdItem",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
