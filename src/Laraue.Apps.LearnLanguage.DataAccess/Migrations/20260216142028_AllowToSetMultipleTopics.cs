using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AllowToSetMultipleTopics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_topics_quiz_topic_id",
                table: "users");

            migrationBuilder.CreateTable(
                name: "user_quiz_topics",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    topic_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_quiz_topics", x => new { x.user_id, x.topic_id });
                    table.ForeignKey(
                        name: "fk_user_quiz_topics_topics_topic_id",
                        column: x => x.topic_id,
                        principalTable: "topics",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_quiz_topics_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.Sql("insert into user_quiz_topics (user_id, topic_id)" +
                                 "select id, quiz_topic_id from users where quiz_topic_id is not null;");

            migrationBuilder.DropIndex(
                name: "ix_users_quiz_topic_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "quiz_topic_id",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "ix_user_quiz_topics_topic_id",
                table: "user_quiz_topics",
                column: "topic_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_quiz_topics");

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
    }
}
