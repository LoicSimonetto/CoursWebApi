using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfieAWookies.NET.Selfies.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class SelfiesWookieAndPictureIdsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selfie_Pictures_PictureId",
                table: "Selfie");

            migrationBuilder.DropForeignKey(
                name: "FK_Selfie_Wookie_WookieId",
                table: "Selfie");

            migrationBuilder.AlterColumn<int>(
                name: "WookieId",
                table: "Selfie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PictureId",
                table: "Selfie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Selfie_Pictures_PictureId",
                table: "Selfie",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Selfie_Wookie_WookieId",
                table: "Selfie",
                column: "WookieId",
                principalTable: "Wookie",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selfie_Pictures_PictureId",
                table: "Selfie");

            migrationBuilder.DropForeignKey(
                name: "FK_Selfie_Wookie_WookieId",
                table: "Selfie");

            migrationBuilder.AlterColumn<int>(
                name: "WookieId",
                table: "Selfie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PictureId",
                table: "Selfie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Selfie_Pictures_PictureId",
                table: "Selfie",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Selfie_Wookie_WookieId",
                table: "Selfie",
                column: "WookieId",
                principalTable: "Wookie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
