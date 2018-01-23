using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NextSugarCat.Migrations
{
    public partial class PriceSetupChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemPrices",
                table: "MenuItemPrices");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "MenuItemPrices");

            migrationBuilder.DropColumn(
                name: "CupcakePrice12pc",
                table: "MenuItemPrices");

            migrationBuilder.DropColumn(
                name: "CupcakePrice24pc",
                table: "MenuItemPrices");

            migrationBuilder.DropColumn(
                name: "CupcakePrice6pc",
                table: "MenuItemPrices");

            migrationBuilder.DropColumn(
                name: "MacaroonPrice12pc",
                table: "MenuItemPrices");

            migrationBuilder.DropColumn(
                name: "MacaroonPrice1pc",
                table: "MenuItemPrices");

            migrationBuilder.DropColumn(
                name: "MacaroonPrice3pc",
                table: "MenuItemPrices");

            migrationBuilder.DropColumn(
                name: "MacaroonPrice6pc",
                table: "MenuItemPrices");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MenuItemPrices",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemPrices",
                table: "MenuItemPrices",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SetPrices",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuItemPriceId = table.Column<int>(nullable: true),
                    SetPrice = table.Column<int>(nullable: false),
                    SetSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetPrices", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_SetPrices_MenuItemPrices_MenuItemPriceId",
                        column: x => x.MenuItemPriceId,
                        principalTable: "MenuItemPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetPrices_MenuItemPriceId",
                table: "SetPrices",
                column: "MenuItemPriceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemPrices",
                table: "MenuItemPrices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MenuItemPrices");

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "MenuItemPrices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CupcakePrice12pc",
                table: "MenuItemPrices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CupcakePrice24pc",
                table: "MenuItemPrices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CupcakePrice6pc",
                table: "MenuItemPrices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MacaroonPrice12pc",
                table: "MenuItemPrices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MacaroonPrice1pc",
                table: "MenuItemPrices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MacaroonPrice3pc",
                table: "MenuItemPrices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MacaroonPrice6pc",
                table: "MenuItemPrices",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemPrices",
                table: "MenuItemPrices",
                columns: new[] { "PriceId", "MenuItemId" });
        }
    }
}
