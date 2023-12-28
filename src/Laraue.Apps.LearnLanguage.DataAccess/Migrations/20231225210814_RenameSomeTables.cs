using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameSomeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_repeat_sessions_user_id",
                table: "repeat_sessions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_repeat_session_words",
                table: "repeat_session_words");

            migrationBuilder.RenameColumn(
                name: "view_count",
                table: "word_translation_states",
                newName: "learn_attempts");

            migrationBuilder.RenameColumn(
                name: "view_count",
                table: "repeat_session_words",
                newName: "repeat_session_word_state");

            migrationBuilder.AddColumn<DateTime>(
                name: "finished_at",
                table: "repeat_sessions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "started_at",
                table: "repeat_sessions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "id",
                table: "repeat_session_words",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_repeat_session_words",
                table: "repeat_session_words",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_repeat_sessions_user_id",
                table: "repeat_sessions",
                column: "user_id",
                unique: true,
                filter: "state <> 2");

            migrationBuilder.CreateIndex(
                name: "ix_repeat_session_words_word_translation_id_repeat_session_id",
                table: "repeat_session_words",
                columns: new[] { "word_translation_id", "repeat_session_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_repeat_sessions_user_id",
                table: "repeat_sessions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_repeat_session_words",
                table: "repeat_session_words");

            migrationBuilder.DropIndex(
                name: "ix_repeat_session_words_word_translation_id_repeat_session_id",
                table: "repeat_session_words");

            migrationBuilder.DropColumn(
                name: "finished_at",
                table: "repeat_sessions");

            migrationBuilder.DropColumn(
                name: "started_at",
                table: "repeat_sessions");

            migrationBuilder.DropColumn(
                name: "id",
                table: "repeat_session_words");

            migrationBuilder.RenameColumn(
                name: "learn_attempts",
                table: "word_translation_states",
                newName: "view_count");

            migrationBuilder.RenameColumn(
                name: "repeat_session_word_state",
                table: "repeat_session_words",
                newName: "view_count");

            migrationBuilder.AddPrimaryKey(
                name: "pk_repeat_session_words",
                table: "repeat_session_words",
                columns: new[] { "word_translation_id", "repeat_session_id" });

            migrationBuilder.CreateIndex(
                name: "ix_repeat_sessions_user_id",
                table: "repeat_sessions",
                column: "user_id");
        }
    }
}
