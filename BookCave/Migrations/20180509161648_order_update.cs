using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookCave.Migrations
{
    public partial class order_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingInfo_ShippingInfoId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingInfoId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingInfoId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Cart",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "SendingMethod",
                table: "ShippingInfo",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "OrderItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendingMethod",
                table: "ShippingInfo");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cart",
                newName: "CartId");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ShippingInfoId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingInfoId",
                table: "Orders",
                column: "ShippingInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingInfo_ShippingInfoId",
                table: "Orders",
                column: "ShippingInfoId",
                principalTable: "ShippingInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
