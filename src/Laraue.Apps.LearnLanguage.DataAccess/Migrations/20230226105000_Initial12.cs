using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_word_translation_states_word_translation_id_user_id",
                table: "word_translation_states");

            migrationBuilder.DropForeignKey(
                name: "fk_word_translation_states_users_user_id",
                table: "word_translation_states");
            
            migrationBuilder.DropForeignKey(
                name: "fk_word_groups_users_user_id",
                table: "word_groups");
            
            migrationBuilder.Sql(
                "ALTER TABLE users ALTER COLUMN id TYPE uuid USING id::uuid");

            migrationBuilder.Sql(
                "ALTER TABLE word_translation_states ALTER COLUMN user_id TYPE uuid USING user_id::uuid");

            migrationBuilder.Sql(
                "ALTER TABLE word_groups ALTER COLUMN user_id TYPE uuid USING user_id::uuid");
            
            migrationBuilder.AddForeignKey(
                name: "fk_word_translation_states_users_user_id",
                table: "word_translation_states",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            
            migrationBuilder.AddForeignKey(
                name: "fk_word_groups_users_user_id",
                table: "word_groups",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
                name: "ix_word_translation_states_word_translation_id",
                table: "word_translation_states",
                column: "word_translation_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_word_translation_states_word_translation_id",
                table: "word_translation_states");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "word_translation_states",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "word_groups",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "ix_word_translation_states_word_translation_id_user_id",
                table: "word_translation_states",
                columns: new[] { "word_translation_id", "user_id" },
                unique: true);
        }
    }
}
