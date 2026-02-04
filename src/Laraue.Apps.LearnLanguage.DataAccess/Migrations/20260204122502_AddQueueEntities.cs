using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddQueueEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "failed_updates",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    body = table.Column<string>(type: "text", nullable: false),
                    error = table.Column<string>(type: "text", nullable: false),
                    stack_trace = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_failed_updates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "updates",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    body = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_updates", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5405L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "приурочить", "priurochit'" });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 5405L,
                column: "transcription",
                value: "tai:m");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "failed_updates");

            migrationBuilder.DropTable(
                name: "updates");

            migrationBuilder.UpdateData(
                table: "translations",
                keyColumns: new[] { "language_id", "word_id" },
                keyValues: new object[] { 2L, 5405L },
                columns: new[] { "text", "transcription" },
                values: new object[] { "тратить (tratit')", "tratit'" });

            migrationBuilder.UpdateData(
                table: "words",
                keyColumn: "id",
                keyValue: 5405L,
                column: "transcription",
                value: "tahm");
        }
    }
}
