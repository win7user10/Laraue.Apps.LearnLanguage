using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRepeatSessionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "repeated_at",
                table: "word_translation_states",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "repeat_sessions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_repeat_sessions", x => x.id);
                    table.ForeignKey(
                        name: "fk_repeat_sessions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "repeat_session_words",
                columns: table => new
                {
                    word_translation_id = table.Column<long>(type: "bigint", nullable: false),
                    repeat_session_id = table.Column<long>(type: "bigint", nullable: false),
                    view_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_repeat_session_words", x => new { x.word_translation_id, x.repeat_session_id });
                    table.ForeignKey(
                        name: "fk_repeat_session_words_repeat_sessions_repeat_session_id",
                        column: x => x.repeat_session_id,
                        principalTable: "repeat_sessions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_repeat_session_words_word_translations_word_translation_id",
                        column: x => x.word_translation_id,
                        principalTable: "word_translations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_repeat_session_words_repeat_session_id",
                table: "repeat_session_words",
                column: "repeat_session_id");

            migrationBuilder.CreateIndex(
                name: "ix_repeat_sessions_user_id",
                table: "repeat_sessions",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "repeat_session_words");

            migrationBuilder.DropTable(
                name: "repeat_sessions");

            migrationBuilder.DropColumn(
                name: "repeated_at",
                table: "word_translation_states");
        }
    }
}
