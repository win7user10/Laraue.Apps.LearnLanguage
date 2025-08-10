using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddJapaneseWords2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "translations",
                columns: new[] { "id", "language_id", "meaning_id", "word_id", "average_attempts", "difficulty", "text" },
                values: new object[,]
                {
                    { 3L, 4L, 1L, 4670L, null, null, "yard（ヤード）" },
                    { 3L, 4L, 1L, 4671L, null, null, "あくび" },
                    { 3L, 4L, 1L, 4672L, null, null, "憧れ" },
                    { 3L, 4L, 1L, 4673L, null, null, "怒鳴る" },
                    { 3L, 4L, 1L, 4674L, null, null, "まだ" }
                });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 4673L,
                column: "transcription",
                value: "donaru");

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 4674L,
                column: "transcription",
                value: "ma da");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4670L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4671L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4672L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4673L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4674L });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 4673L,
                column: "transcription",
                value: null);

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 4674L,
                column: "transcription",
                value: null);
        }
    }
}
