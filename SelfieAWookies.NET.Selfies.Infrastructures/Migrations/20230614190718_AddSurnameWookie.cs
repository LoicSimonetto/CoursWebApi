using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfieAWookies.NET.Selfies.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddSurnameWookie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Wookie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Wookie");
        }
    }
}
