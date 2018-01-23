using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NextSugarCat.Migrations
{
    public partial class SetPriceFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetPrices_MenuItemPrices_MenuItemPriceId",
                table: "SetPrices");

            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "SetPrices",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemPriceId",
                table: "SetPrices",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SetPrices_MenuItemPrices_MenuItemPriceId",
                table: "SetPrices",
                column: "MenuItemPriceId",
                principalTable: "MenuItemPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetPrices_MenuItemPrices_MenuItemPriceId",
                table: "SetPrices");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SetPrices",
                newName: "MenuItemId");

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemPriceId",
                table: "SetPrices",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SetPrices_MenuItemPrices_MenuItemPriceId",
                table: "SetPrices",
                column: "MenuItemPriceId",
                principalTable: "MenuItemPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
