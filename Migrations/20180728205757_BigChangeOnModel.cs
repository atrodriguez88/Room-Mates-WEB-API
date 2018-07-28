using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomM.API.Migrations
{
    public partial class BigChangeOnModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Profiles_ProfileId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ProfileId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Rooms",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId1",
                table: "Rooms",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AspNetUsers_UserId1",
                table: "Rooms",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AspNetUsers_UserId1",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_UserId1",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Rooms",
                newName: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ProfileId",
                table: "Rooms",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Profiles_ProfileId",
                table: "Rooms",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
