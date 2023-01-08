using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hide_translations",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "word_template_mode",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "work_mode",
                table: "users",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "word_template_mode",
                table: "users");

            migrationBuilder.DropColumn(
                name: "work_mode",
                table: "users");

            migrationBuilder.AddColumn<bool>(
                name: "hide_translations",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
