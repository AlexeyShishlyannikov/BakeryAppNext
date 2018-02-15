using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NextSugarCat.Migrations
{
    public partial class SeedContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Google",
                table: "Contacts",
                newName: "Address");
            migrationBuilder.Sql("SET IDENTITY_INSERT Contacts ON");
            migrationBuilder.Sql("INSERT INTO Contacts (Id, Phone, Facebook, Instagram, Email, Address) VALUES (1, '1234567890', 'facebookurl', 'instagramurl', 'email@add.com', 'Chicago, IL 60660')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Contacts",
                newName: "Google");
        }
    }
}
