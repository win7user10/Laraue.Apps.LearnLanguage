using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSessionTranslation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_repeat_sessions_languages_language_to_learn_from_id",
                table: "repeat_sessions");

            migrationBuilder.DropForeignKey(
                name: "fk_repeat_sessions_languages_language_to_learn_id",
                table: "repeat_sessions");

            migrationBuilder.DropColumn(
                name: "language_id_to_learn",
                table: "repeat_sessions");

            migrationBuilder.DropColumn(
                name: "language_id_to_learn_from",
                table: "repeat_sessions");

            migrationBuilder.AlterColumn<long>(
                name: "language_to_learn_id",
                table: "repeat_sessions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "language_to_learn_from_id",
                table: "repeat_sessions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "fk_repeat_sessions_languages_language_to_learn_from_id",
                table: "repeat_sessions",
                column: "language_to_learn_from_id",
                principalTable: "languages",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_repeat_sessions_languages_language_to_learn_id",
                table: "repeat_sessions",
                column: "language_to_learn_id",
                principalTable: "languages",
                principalColumn: "id");
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

            migrationBuilder.AlterColumn<long>(
                name: "language_to_learn_id",
                table: "repeat_sessions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "language_to_learn_from_id",
                table: "repeat_sessions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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
    }
}
