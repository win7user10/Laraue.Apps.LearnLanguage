using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "telegram_identity_user",
                newName: "users");

            migrationBuilder.Sql("update users set hide_translations = false");
            
            migrationBuilder.AlterColumn<bool>(
                name: "hide_translations",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "hide_translations",
                table: "telegram_identity_user",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<string>(
                name: "discriminator",
                table: "telegram_identity_user",
                type: "text",
                nullable: false,
                defaultValue: "");

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
    }
}
