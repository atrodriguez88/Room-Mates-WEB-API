using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RoomM.API.Migrations
{
    public partial class ModifyModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdTitle",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AdDescription",
                table: "AspNetUsers",
                newName: "AboutMe");

            migrationBuilder.AddColumn<string>(
                name: "AdDescription",
                table: "Rooms",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdTitle",
                table: "Rooms",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdDescription",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "AdTitle",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "AboutMe",
                table: "AspNetUsers",
                newName: "AdDescription");

            migrationBuilder.AddColumn<string>(
                name: "AdTitle",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: true);
        }
    }
}
