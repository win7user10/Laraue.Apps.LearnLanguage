using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeJapaneseWords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "translations",
                columns: new[] { "id", "language_id", "meaning_id", "word_id", "average_attempts", "difficulty", "text" },
                values: new object[,]
                {
                    { 3L, 4L, 1L, 4675L, null, null, "歩留まり" },
                    { 3L, 4L, 1L, 4676L, null, null, "ティーン" },
                    { 3L, 4L, 1L, 4677L, null, null, "ユース" },
                    { 3L, 4L, 1L, 4678L, null, null, "ジール" },
                    { 3L, 4L, 1L, 4679L, null, null, "ジッパー" },
                    { 3L, 4L, 1L, 4680L, null, null, "動物園" },
                    { 3L, 4L, 1L, 4681L, null, null, "カラント" },
                    { 3L, 4L, 1L, 4682L, null, null, "ブラックベリー" },
                    { 3L, 4L, 1L, 4683L, null, null, "ブルーベリー" },
                    { 3L, 4L, 1L, 4684L, null, null, "チェリー" },
                    { 3L, 4L, 1L, 4685L, null, null, "ぶどう" },
                    { 3L, 4L, 1L, 4686L, null, null, "スイカ" },
                    { 3L, 4L, 1L, 4687L, null, null, "クランベリー" },
                    { 3L, 4L, 1L, 4688L, null, null, "グーズベリー" }
                });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 4676L,
                column: "transcription",
                value: "tin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4675L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4676L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4677L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4678L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4679L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4680L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4681L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4682L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4683L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4684L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4685L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4686L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4687L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4688L });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 4676L,
                column: "transcription",
                value: null);
        }
    }
}
