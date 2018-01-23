using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NextSugarCat.Migrations
{
    public partial class ByteHashedPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Photos",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Length",
                table: "Photos",
                nullable: false,
                defaultValue: 0L);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_IdentityId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IdentityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Orders");
        }
    }
}
