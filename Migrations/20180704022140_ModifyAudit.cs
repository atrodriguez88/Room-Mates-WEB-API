using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomM.API.Migrations
{
    public partial class ModifyAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_AspNetUsers_CreatedBy",
                table: "Preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_AspNetUsers_DeletedBy",
                table: "Preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_AspNetUsers_UpdatedBy",
                table: "Preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_CreatedBy",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_DeletedBy",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_UpdatedBy",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatures_AspNetUsers_CreatedBy",
                table: "PropertyFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatures_AspNetUsers_DeletedBy",
                table: "PropertyFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyFeatures_AspNetUsers_UpdatedBy",
                table: "PropertyFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyRules_AspNetUsers_CreatedBy",
                table: "PropertyRules");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyRules_AspNetUsers_DeletedBy",
                table: "PropertyRules");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyRules_AspNetUsers_UpdatedBy",
                table: "PropertyRules");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTypes_AspNetUsers_CreatedBy",
                table: "PropertyTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTypes_AspNetUsers_DeletedBy",
                table: "PropertyTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyTypes_AspNetUsers_UpdatedBy",
                table: "PropertyTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFeatures_AspNetUsers_CreatedBy",
                table: "RoomFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFeatures_AspNetUsers_DeletedBy",
                table: "RoomFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFeatures_AspNetUsers_UpdatedBy",
                table: "RoomFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AspNetUsers_CreatedBy",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AspNetUsers_DeletedBy",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AspNetUsers_UpdatedBy",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CreatedBy",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_DeletedBy",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_UpdatedBy",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_RoomFeatures_CreatedBy",
                table: "RoomFeatures");

            migrationBuilder.DropIndex(
                name: "IX_RoomFeatures_DeletedBy",
                table: "RoomFeatures");

            migrationBuilder.DropIndex(
                name: "IX_RoomFeatures_UpdatedBy",
                table: "RoomFeatures");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTypes_CreatedBy",
                table: "PropertyTypes");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTypes_DeletedBy",
                table: "PropertyTypes");

            migrationBuilder.DropIndex(
                name: "IX_PropertyTypes_UpdatedBy",
                table: "PropertyTypes");

            migrationBuilder.DropIndex(
                name: "IX_PropertyRules_CreatedBy",
                table: "PropertyRules");

            migrationBuilder.DropIndex(
                name: "IX_PropertyRules_DeletedBy",
                table: "PropertyRules");

            migrationBuilder.DropIndex(
                name: "IX_PropertyRules_UpdatedBy",
                table: "PropertyRules");

            migrationBuilder.DropIndex(
                name: "IX_PropertyFeatures_CreatedBy",
                table: "PropertyFeatures");

            migrationBuilder.DropIndex(
                name: "IX_PropertyFeatures_DeletedBy",
                table: "PropertyFeatures");

            migrationBuilder.DropIndex(
                name: "IX_PropertyFeatures_UpdatedBy",
                table: "PropertyFeatures");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_CreatedBy",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_DeletedBy",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UpdatedBy",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_CreatedBy",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_DeletedBy",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_UpdatedBy",
                table: "Preferences");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "RoomFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "RoomFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "RoomFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "PropertyTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "PropertyTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PropertyTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "PropertyRules",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "PropertyRules",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PropertyRules",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "PropertyFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "PropertyFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PropertyFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Profiles",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Profiles",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Profiles",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Preferences",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Preferences",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Preferences",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "RoomFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "RoomFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "RoomFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "PropertyTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "PropertyTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PropertyTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "PropertyRules",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "PropertyRules",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PropertyRules",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "PropertyFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "PropertyFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PropertyFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Profiles",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Profiles",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Profiles",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Preferences",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Preferences",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Preferences",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CreatedBy",
                table: "Rooms",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DeletedBy",
                table: "Rooms",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UpdatedBy",
                table: "Rooms",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatures_CreatedBy",
                table: "RoomFeatures",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatures_DeletedBy",
                table: "RoomFeatures",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFeatures_UpdatedBy",
                table: "RoomFeatures",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypes_CreatedBy",
                table: "PropertyTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypes_DeletedBy",
                table: "PropertyTypes",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTypes_UpdatedBy",
                table: "PropertyTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRules_CreatedBy",
                table: "PropertyRules",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRules_DeletedBy",
                table: "PropertyRules",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyRules_UpdatedBy",
                table: "PropertyRules",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_CreatedBy",
                table: "PropertyFeatures",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_DeletedBy",
                table: "PropertyFeatures",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyFeatures_UpdatedBy",
                table: "PropertyFeatures",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CreatedBy",
                table: "Profiles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_DeletedBy",
                table: "Profiles",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UpdatedBy",
                table: "Profiles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_CreatedBy",
                table: "Preferences",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_DeletedBy",
                table: "Preferences",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_UpdatedBy",
                table: "Preferences",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_AspNetUsers_CreatedBy",
                table: "Preferences",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_AspNetUsers_DeletedBy",
                table: "Preferences",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_AspNetUsers_UpdatedBy",
                table: "Preferences",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_CreatedBy",
                table: "Profiles",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_DeletedBy",
                table: "Profiles",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_UpdatedBy",
                table: "Profiles",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatures_AspNetUsers_CreatedBy",
                table: "PropertyFeatures",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatures_AspNetUsers_DeletedBy",
                table: "PropertyFeatures",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyFeatures_AspNetUsers_UpdatedBy",
                table: "PropertyFeatures",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyRules_AspNetUsers_CreatedBy",
                table: "PropertyRules",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyRules_AspNetUsers_DeletedBy",
                table: "PropertyRules",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyRules_AspNetUsers_UpdatedBy",
                table: "PropertyRules",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTypes_AspNetUsers_CreatedBy",
                table: "PropertyTypes",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTypes_AspNetUsers_DeletedBy",
                table: "PropertyTypes",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyTypes_AspNetUsers_UpdatedBy",
                table: "PropertyTypes",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFeatures_AspNetUsers_CreatedBy",
                table: "RoomFeatures",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFeatures_AspNetUsers_DeletedBy",
                table: "RoomFeatures",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFeatures_AspNetUsers_UpdatedBy",
                table: "RoomFeatures",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AspNetUsers_CreatedBy",
                table: "Rooms",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AspNetUsers_DeletedBy",
                table: "Rooms",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AspNetUsers_UpdatedBy",
                table: "Rooms",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
