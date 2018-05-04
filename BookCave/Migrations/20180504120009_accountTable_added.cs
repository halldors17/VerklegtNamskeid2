using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class accountTable_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "OrderItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "BookIdItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId1",
                table: "BookIdItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId2",
                table: "BookIdItem",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ShippingId = table.Column<int>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_ShippingInfo_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "ShippingInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_AccountId",
                table: "OrderItem",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIdItem_AccountId",
                table: "BookIdItem",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIdItem_AccountId1",
                table: "BookIdItem",
                column: "AccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_BookIdItem_AccountId2",
                table: "BookIdItem",
                column: "AccountId2");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ShippingId",
                table: "Accounts",
                column: "ShippingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIdItem_Accounts_AccountId",
                table: "BookIdItem",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookIdItem_Accounts_AccountId1",
                table: "BookIdItem",
                column: "AccountId1",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookIdItem_Accounts_AccountId2",
                table: "BookIdItem",
                column: "AccountId2",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Accounts_AccountId",
                table: "OrderItem",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIdItem_Accounts_AccountId",
                table: "BookIdItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BookIdItem_Accounts_AccountId1",
                table: "BookIdItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BookIdItem_Accounts_AccountId2",
                table: "BookIdItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Accounts_AccountId",
                table: "OrderItem");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_AccountId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_BookIdItem_AccountId",
                table: "BookIdItem");

            migrationBuilder.DropIndex(
                name: "IX_BookIdItem_AccountId1",
                table: "BookIdItem");

            migrationBuilder.DropIndex(
                name: "IX_BookIdItem_AccountId2",
                table: "BookIdItem");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "BookIdItem");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "BookIdItem");

            migrationBuilder.DropColumn(
                name: "AccountId2",
                table: "BookIdItem");
        }
    }
}
