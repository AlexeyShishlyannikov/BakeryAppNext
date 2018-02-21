using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NextSugarCat.Migrations
{
    public partial class RegisterFormValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Town",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Clients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Clients",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Clients",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Clients",
                nullable: true);
        }
    }
}
