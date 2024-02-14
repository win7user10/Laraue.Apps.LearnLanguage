using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTestFrenchTranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "id", "code" },
                values: new object[] { 3L, "fr" });

            migrationBuilder.InsertData(
                table: "word_translations",
                columns: new[] { "id", "average_attempts", "difficulty", "language_id", "translation", "word_meaning_id" },
                values: new object[,]
                {
                    { 4681L, null, null, 3L, "abandonner", 1L },
                    { 4682L, null, null, 3L, "diminuer", 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4681L);

            migrationBuilder.DeleteData(
                table: "word_translations",
                keyColumn: "id",
                keyValue: 4682L);

            migrationBuilder.DeleteData(
                table: "languages",
                keyColumn: "id",
                keyValue: 3L);
        }
    }
}
