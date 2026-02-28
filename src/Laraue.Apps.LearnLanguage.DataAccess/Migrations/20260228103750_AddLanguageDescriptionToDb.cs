using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguageDescriptionToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "languages",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "id",
                keyValue: 1L,
                column: "description",
                value: "English");

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "id",
                keyValue: 2L,
                column: "description",
                value: "Russian");

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "id",
                keyValue: 3L,
                column: "description",
                value: "French");

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "id",
                keyValue: 4L,
                column: "description",
                value: "Japanese");

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "id",
                keyValue: 5L,
                column: "description",
                value: "Spanish");

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "id",
                keyValue: 6L,
                column: "description",
                value: "German");

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "id",
                keyValue: 7L,
                column: "description",
                value: "Chinese");

            migrationBuilder.UpdateData(
                table: "languages",
                keyColumn: "id",
                keyValue: 8L,
                column: "description",
                value: "Hindi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "languages");
        }
    }
}
