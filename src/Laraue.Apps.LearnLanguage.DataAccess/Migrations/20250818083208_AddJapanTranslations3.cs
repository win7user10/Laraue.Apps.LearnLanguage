using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddJapanTranslations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "translations",
                columns: new[] { "id", "language_id", "meaning_id", "word_id", "average_attempts", "difficulty", "text" },
                values: new object[,]
                {
                    { 3L, 4L, 1L, 4656L, null, null, "ラップ" },
                    { 3L, 4L, 1L, 4657L, null, null, "怒り" },
                    { 3L, 4L, 1L, 4658L, null, null, "リース" },
                    { 3L, 4L, 1L, 4659L, null, null, "難破船" },
                    { 3L, 4L, 1L, 4660L, null, null, "レンチ" },
                    { 3L, 4L, 1L, 4661L, null, null, "レッスル" },
                    { 3L, 4L, 1L, 4662L, null, null, "惨めな" },
                    { 3L, 4L, 1L, 4663L, null, null, "しわ" },
                    { 3L, 4L, 1L, 4664L, null, null, "手首" },
                    { 3L, 4L, 1L, 4665L, null, null, "書き出す" },
                    { 3L, 4L, 1L, 4666L, null, null, "違うんだ。" },
                    { 3L, 4L, 1L, 4667L, null, null, "不正行為" },
                    { 3L, 4L, 1L, 4668L, null, null, "ヨット" },
                    { 3L, 4L, 1L, 4669L, null, null, "ヤンク" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4656L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4657L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4658L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4659L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4660L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4661L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4662L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4663L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4664L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4665L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4666L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4667L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4668L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 3L, 4L, 1L, 4669L });
        }
    }
}
