using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBerries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "meaning_topics",
                keyColumns: new[] { "meaning_id", "topic_id", "word_id" },
                keyValues: new object[] { 1L, 17L, 4033L });

            migrationBuilder.InsertData(
                table: "meaning_topics",
                columns: new[] { "meaning_id", "topic_id", "word_id" },
                values: new object[,]
                {
                    { 1L, 23L, 3302L },
                    { 1L, 23L, 4033L }
                });

            migrationBuilder.InsertData(
                table: "translations",
                columns: new[] { "id", "language_id", "meaning_id", "word_id", "average_attempts", "difficulty", "text" },
                values: new object[,]
                {
                    { 2L, 3L, 1L, 3302L, null, null, "framboise" },
                    { 2L, 3L, 1L, 4033L, null, null, "fraise" }
                });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 1679L,
                column: "text",
                value: "flight attendant");

            migrationBuilder.InsertData(
                table: "words",
                columns: new[] { "id", "language_id", "text", "transcription" },
                values: new object[,]
                {
                    { 4683L, 1L, "blueberry", "bluːberi" },
                    { 4684L, 1L, "cherry", "tʃeri" },
                    { 4685L, 1L, "grapes", "ɡreɪps" },
                    { 4686L, 1L, "watermelon", "wɔːtərmelən" },
                    { 4687L, 1L, "сranberry", "krænberi" },
                    { 4688L, 1L, "gooseberry", "ɡuːsberi" }
                });

            migrationBuilder.InsertData(
                table: "meanings",
                columns: new[] { "id", "word_id", "cefr_level_id", "text" },
                values: new object[,]
                {
                    { 1L, 4683L, null, null },
                    { 1L, 4684L, null, null },
                    { 1L, 4685L, null, null },
                    { 1L, 4686L, null, null },
                    { 1L, 4687L, null, null },
                    { 1L, 4688L, null, null }
                });

            migrationBuilder.InsertData(
                table: "meaning_topics",
                columns: new[] { "meaning_id", "topic_id", "word_id" },
                values: new object[,]
                {
                    { 1L, 23L, 4683L },
                    { 1L, 23L, 4684L },
                    { 1L, 23L, 4685L },
                    { 1L, 23L, 4686L },
                    { 1L, 23L, 4687L },
                    { 1L, 23L, 4688L }
                });

            migrationBuilder.InsertData(
                table: "translations",
                columns: new[] { "id", "language_id", "meaning_id", "word_id", "average_attempts", "difficulty", "text" },
                values: new object[,]
                {
                    { 1L, 3L, 1L, 4683L, null, null, "myrtille" },
                    { 2L, 2L, 1L, 4683L, null, null, "брусника, голубика" },
                    { 1L, 2L, 1L, 4684L, null, null, "вишня, черешня" },
                    { 2L, 3L, 1L, 4684L, null, null, "cerise" },
                    { 1L, 2L, 1L, 4685L, null, null, "виноград" },
                    { 2L, 3L, 1L, 4685L, null, null, "raisin" },
                    { 1L, 3L, 1L, 4686L, null, null, "pastèque" },
                    { 2L, 2L, 1L, 4686L, null, null, "арбуз" },
                    { 1L, 3L, 1L, 4687L, null, null, "canneberge" },
                    { 2L, 2L, 1L, 4687L, null, null, "клюква" },
                    { 1L, 2L, 1L, 4688L, null, null, "крыжовник" },
                    { 2L, 3L, 1L, 4688L, null, null, "groseilliers" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "meaning_topics",
                keyColumns: new[] { "meaning_id", "topic_id", "word_id" },
                keyValues: new object[] { 1L, 23L, 3302L });

            migrationBuilder.DeleteData(
                table: "meaning_topics",
                keyColumns: new[] { "meaning_id", "topic_id", "word_id" },
                keyValues: new object[] { 1L, 23L, 4033L });

            migrationBuilder.DeleteData(
                table: "meaning_topics",
                keyColumns: new[] { "meaning_id", "topic_id", "word_id" },
                keyValues: new object[] { 1L, 23L, 4683L });

            migrationBuilder.DeleteData(
                table: "meaning_topics",
                keyColumns: new[] { "meaning_id", "topic_id", "word_id" },
                keyValues: new object[] { 1L, 23L, 4684L });

            migrationBuilder.DeleteData(
                table: "meaning_topics",
                keyColumns: new[] { "meaning_id", "topic_id", "word_id" },
                keyValues: new object[] { 1L, 23L, 4685L });

            migrationBuilder.DeleteData(
                table: "meaning_topics",
                keyColumns: new[] { "meaning_id", "topic_id", "word_id" },
                keyValues: new object[] { 1L, 23L, 4686L });

            migrationBuilder.DeleteData(
                table: "meaning_topics",
                keyColumns: new[] { "meaning_id", "topic_id", "word_id" },
                keyValues: new object[] { 1L, 23L, 4687L });

            migrationBuilder.DeleteData(
                table: "meaning_topics",
                keyColumns: new[] { "meaning_id", "topic_id", "word_id" },
                keyValues: new object[] { 1L, 23L, 4688L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 2L, 3L, 1L, 3302L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 2L, 3L, 1L, 4033L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 1L, 3L, 1L, 4683L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 2L, 2L, 1L, 4683L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 1L, 2L, 1L, 4684L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 2L, 3L, 1L, 4684L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 1L, 2L, 1L, 4685L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 2L, 3L, 1L, 4685L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 1L, 3L, 1L, 4686L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 2L, 2L, 1L, 4686L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 1L, 3L, 1L, 4687L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 2L, 2L, 1L, 4687L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 1L, 2L, 1L, 4688L });

            migrationBuilder.DeleteData(
                table: "translations",
                keyColumns: new[] { "id", "language_id", "meaning_id", "word_id" },
                keyValues: new object[] { 2L, 3L, 1L, 4688L });

            migrationBuilder.DeleteData(
                table: "meanings",
                keyColumns: new[] { "id", "word_id" },
                keyValues: new object[] { 1L, 4683L });

            migrationBuilder.DeleteData(
                table: "meanings",
                keyColumns: new[] { "id", "word_id" },
                keyValues: new object[] { 1L, 4684L });

            migrationBuilder.DeleteData(
                table: "meanings",
                keyColumns: new[] { "id", "word_id" },
                keyValues: new object[] { 1L, 4685L });

            migrationBuilder.DeleteData(
                table: "meanings",
                keyColumns: new[] { "id", "word_id" },
                keyValues: new object[] { 1L, 4686L });

            migrationBuilder.DeleteData(
                table: "meanings",
                keyColumns: new[] { "id", "word_id" },
                keyValues: new object[] { 1L, 4687L });

            migrationBuilder.DeleteData(
                table: "meanings",
                keyColumns: new[] { "id", "word_id" },
                keyValues: new object[] { 1L, 4688L });

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "id",
                keyValue: 4683L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "id",
                keyValue: 4684L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "id",
                keyValue: 4685L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "id",
                keyValue: 4686L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "id",
                keyValue: 4687L);

            migrationBuilder.DeleteData(
                table: "words",
                keyColumn: "id",
                keyValue: 4688L);

            migrationBuilder.InsertData(
                table: "meaning_topics",
                columns: new[] { "meaning_id", "topic_id", "word_id" },
                values: new object[] { 1L, 17L, 4033L });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 1679L,
                column: "text",
                value: "flight attendant");
        }
    }
}
