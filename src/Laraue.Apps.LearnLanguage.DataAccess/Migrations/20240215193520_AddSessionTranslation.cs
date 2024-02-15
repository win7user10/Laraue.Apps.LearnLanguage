using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSessionTranslation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "language_id_to_learn",
                table: "repeat_sessions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "language_id_to_learn_from",
                table: "repeat_sessions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "language_to_learn_from_id",
                table: "repeat_sessions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "language_to_learn_id",
                table: "repeat_sessions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.Sql(@"update repeat_sessions set language_to_learn_id = 1, language_to_learn_from_id = 2");

            migrationBuilder.CreateIndex(
                name: "ix_repeat_sessions_language_to_learn_from_id",
                table: "repeat_sessions",
                column: "language_to_learn_from_id");

            migrationBuilder.CreateIndex(
                name: "ix_repeat_sessions_language_to_learn_id",
                table: "repeat_sessions",
                column: "language_to_learn_id");

            migrationBuilder.AddForeignKey(
                name: "fk_repeat_sessions_languages_language_to_learn_from_id",
                table: "repeat_sessions",
                column: "language_to_learn_from_id",
                principalTable: "languages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_repeat_sessions_languages_language_to_learn_id",
                table: "repeat_sessions",
                column: "language_to_learn_id",
                principalTable: "languages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_repeat_sessions_languages_language_to_learn_from_id",
                table: "repeat_sessions");

            migrationBuilder.DropForeignKey(
                name: "fk_repeat_sessions_languages_language_to_learn_id",
                table: "repeat_sessions");

            migrationBuilder.DropIndex(
                name: "ix_repeat_sessions_language_to_learn_from_id",
                table: "repeat_sessions");

            migrationBuilder.DropIndex(
                name: "ix_repeat_sessions_language_to_learn_id",
                table: "repeat_sessions");

            migrationBuilder.DropColumn(
                name: "language_id_to_learn",
                table: "repeat_sessions");

            migrationBuilder.DropColumn(
                name: "language_id_to_learn_from",
                table: "repeat_sessions");

            migrationBuilder.DropColumn(
                name: "language_to_learn_from_id",
                table: "repeat_sessions");

            migrationBuilder.DropColumn(
                name: "language_to_learn_id",
                table: "repeat_sessions");
        }
    }
}
