using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixTranslationsBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1613L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "удвоение", "udvoenie" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1613L },
                column: "text",
                value: "il/elle/on");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2468L },
                column: "text",
                value: "должен");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2468L },
                column: "text",
                value: "しなければならない");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4756L },
                column: "text",
                value: "заниматься шопингом");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4764L },
                column: "text",
                value: "должен");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5021L },
                column: "text",
                value: "быть звёздой");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5242L },
                column: "text",
                value: "останавливать");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5242L },
                column: "text",
                value: "タックルする");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5820L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "который", "ko-to-ryi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 1613L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "он/она/оно (double refers to a pair)", "on/ona/ono" });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 3L, 1613L },
                column: "text",
                value: "il/elle/on (representing a double)");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 2468L },
                column: "text",
                value: "должен (dolzhen) - masculine, должна (dolzhna) - feminine, должны (dolzhny) - plural");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 2468L },
                column: "text",
                value: "しなければならない (shinakereba naranai)");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4756L },
                column: "text",
                value: "шопировать");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 4764L },
                column: "text",
                value: "должен (dolzhen)");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5021L },
                column: "text",
                value: "помечать звёздами");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5242L },
                column: "text",
                value: "останавливать (ostanavlivat')");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 4L, 5242L },
                column: "text",
                value: "タックルする (takkaru suru)");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5820L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "которого/которой/которого/которых", "ko-to-ro-go/ko-to-ro-y/ko-to-ro-go/ko-to-ryh" });
        }
    }
}
