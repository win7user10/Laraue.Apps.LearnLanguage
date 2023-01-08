using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_word_groups_users_user_id",
                table: "word_groups");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "telegram_identity_user");

            migrationBuilder.AddColumn<string>(
                name: "discriminator",
                table: "telegram_identity_user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "hide_translations",
                table: "telegram_identity_user",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_telegram_identity_user",
                table: "telegram_identity_user",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_word_groups_telegram_identity_user_user_id",
                table: "word_groups",
                column: "user_id",
                principalTable: "telegram_identity_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_word_groups_telegram_identity_user_user_id",
                table: "word_groups");

            migrationBuilder.DropPrimaryKey(
                name: "pk_telegram_identity_user",
                table: "telegram_identity_user");

            migrationBuilder.DropColumn(
                name: "discriminator",
                table: "telegram_identity_user");

            migrationBuilder.DropColumn(
                name: "hide_translations",
                table: "telegram_identity_user");

            migrationBuilder.RenameTable(
                name: "telegram_identity_user",
                newName: "users");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_word_groups_users_user_id",
                table: "word_groups",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
