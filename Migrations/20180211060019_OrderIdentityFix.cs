using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NextSugarCat.Migrations
{
    public partial class OrderIdentityFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_IdentityId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IdentityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdentityId",
                table: "Orders",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_IdentityId",
                table: "Orders",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
