using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPrefferedLanguageColumnsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "language_to_learn_from_id",
                table: "users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "language_to_learn_id",
                table: "users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_language_to_learn_from_id",
                table: "users",
                column: "language_to_learn_from_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_language_to_learn_id",
                table: "users",
                column: "language_to_learn_id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_languages_language_to_learn_from_id",
                table: "users",
                column: "language_to_learn_from_id",
                principalTable: "languages",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_languages_language_to_learn_id",
                table: "users",
                column: "language_to_learn_id",
                principalTable: "languages",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_languages_language_to_learn_from_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "fk_users_languages_language_to_learn_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_language_to_learn_from_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_language_to_learn_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "language_to_learn_from_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "language_to_learn_id",
                table: "users");
        }
    }
}
