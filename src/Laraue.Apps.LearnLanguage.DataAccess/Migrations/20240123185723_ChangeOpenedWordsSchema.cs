using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOpenedWordsSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_opened_translation_ids",
                table: "users");

            migrationBuilder.DropColumn(
                name: "last_translations_open_at",
                table: "users");

            migrationBuilder.AddColumn<DateTime>(
                name: "last_opened_at",
                table: "word_translation_states",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            
            migrationBuilder.Sql(@"update word_translation_states set last_opened_at = '0001-01-01'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_opened_at",
                table: "word_translation_states");

            migrationBuilder.AddColumn<long[]>(
                name: "last_opened_translation_ids",
                table: "users",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_translations_open_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
