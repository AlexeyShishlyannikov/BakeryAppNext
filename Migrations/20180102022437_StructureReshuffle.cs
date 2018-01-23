using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NextSugarCat.Migrations
{
    public partial class StructureReshuffle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemIngredients_Ingredient_IngredientId",
                table: "MenuItemIngredients");

            migrationBuilder.DropTable(
                name: "Cakes");

            migrationBuilder.DropTable(
                name: "Cupcakes");

            migrationBuilder.DropTable(
                name: "Macaroons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "MenuItemIngredients");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "Ingredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MenuItemPrices",
                columns: table => new
                {
                    PriceId = table.Column<int>(nullable: false),
                    MenuItemId = table.Column<int>(nullable: false),
                    CakePricePerPound = table.Column<int>(nullable: true),
                    CupcakePrice12pc = table.Column<int>(nullable: true),
                    CupcakePrice24pc = table.Column<int>(nullable: true),
                    CupcakePrice6pc = table.Column<int>(nullable: true),
                    MacaroonPrice12pc = table.Column<int>(nullable: true),
                    MacaroonPrice1pc = table.Column<int>(nullable: true),
                    MacaroonPrice3pc = table.Column<int>(nullable: true),
                    MacaroonPrice6pc = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemPrices", x => new { x.PriceId, x.MenuItemId });
                    table.ForeignKey(
                        name: "FK_MenuItemPrices_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemPrices_MenuItemId",
                table: "MenuItemPrices",
                column: "MenuItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemIngredients_Ingredients_IngredientId",
                table: "MenuItemIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemIngredients_Ingredients_IngredientId",
                table: "MenuItemIngredients");

            migrationBuilder.DropTable(
                name: "MenuItemPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Ingredient");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "MenuItemIngredients",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cakes",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuItemId1 = table.Column<int>(nullable: true),
                    PricePerPound = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cakes", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_Cakes_MenuItems_MenuItemId1",
                        column: x => x.MenuItemId1,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cupcakes",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuItemId1 = table.Column<int>(nullable: true),
                    Price12pc = table.Column<int>(nullable: false),
                    Price24pc = table.Column<int>(nullable: false),
                    Price6pc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupcakes", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_Cupcakes_MenuItems_MenuItemId1",
                        column: x => x.MenuItemId1,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Macaroons",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuItemId1 = table.Column<int>(nullable: true),
                    PricePer12pc = table.Column<int>(nullable: false),
                    PricePer1pc = table.Column<int>(nullable: false),
                    PricePer3pc = table.Column<int>(nullable: false),
                    PricePer6pc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macaroons", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_Macaroons_MenuItems_MenuItemId1",
                        column: x => x.MenuItemId1,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cakes_MenuItemId1",
                table: "Cakes",
                column: "MenuItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cupcakes_MenuItemId1",
                table: "Cupcakes",
                column: "MenuItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_Macaroons_MenuItemId1",
                table: "Macaroons",
                column: "MenuItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemIngredients_Ingredient_IngredientId",
                table: "MenuItemIngredients",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
