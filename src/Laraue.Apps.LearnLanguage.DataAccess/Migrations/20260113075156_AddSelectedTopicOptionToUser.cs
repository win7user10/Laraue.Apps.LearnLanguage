using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSelectedTopicOptionToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "quiz_topic_id",
                table: "users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_quiz_topic_id",
                table: "users",
                column: "quiz_topic_id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_topics_quiz_topic_id",
                table: "users",
                column: "quiz_topic_id",
                principalTable: "topics",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_topics_quiz_topic_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_quiz_topic_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "quiz_topic_id",
                table: "users");
        }
    }
}
