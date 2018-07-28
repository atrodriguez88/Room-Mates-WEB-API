using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomM.API.Migrations
{
    public partial class BigChangeOnModelOther : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId1",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId1",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfilesId",
                table: "AspNetUsers",
                column: "ProfilesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfilesId",
                table: "AspNetUsers",
                column: "ProfilesId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfilesId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfilesId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Profiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId1",
                table: "Profiles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId1",
                table: "Profiles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
