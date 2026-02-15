using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSelectedCefrToUserQuizes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "cefr_level_id",
                table: "user_quizzes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_quiz_cefr_level_id",
                table: "users",
                column: "quiz_cefr_level_id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_cefr_levels_quiz_cefr_level_id",
                table: "users",
                column: "quiz_cefr_level_id",
                principalTable: "cefr_levels",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_cefr_levels_quiz_cefr_level_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_quiz_cefr_level_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "cefr_level_id",
                table: "user_quizzes");
        }
    }
}
