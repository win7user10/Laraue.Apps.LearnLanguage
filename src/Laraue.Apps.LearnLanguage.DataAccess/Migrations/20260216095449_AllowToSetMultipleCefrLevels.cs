using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AllowToSetMultipleCefrLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "topic_id",
                table: "user_quizzes");

            migrationBuilder.CreateTable(
                name: "user_quiz_cefr_levels",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cefr_level_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_quiz_cefr_levels", x => new { x.user_id, x.cefr_level_id });
                    table.ForeignKey(
                        name: "fk_user_quiz_cefr_levels_cefr_levels_cefr_level_id",
                        column: x => x.cefr_level_id,
                        principalTable: "cefr_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_quiz_cefr_levels_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.Sql("insert into user_quiz_cefr_levels (user_id, cefr_level_id)" +
                                 "select id, quiz_cefr_level_id from users where quiz_cefr_level_id is not null;");
            
            migrationBuilder.DropColumn(
                name: "quiz_cefr_level_id",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "ix_user_quiz_cefr_levels_cefr_level_id",
                table: "user_quiz_cefr_levels",
                column: "cefr_level_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_quiz_cefr_levels");

            migrationBuilder.AddColumn<long>(
                name: "quiz_cefr_level_id",
                table: "users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "cefr_level_id",
                table: "user_quizzes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "topic_id",
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
    }
}
