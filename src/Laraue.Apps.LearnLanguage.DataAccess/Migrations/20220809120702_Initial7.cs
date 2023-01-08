using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    public partial class Initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "work_mode",
                table: "users",
                newName: "show_words_mode");

            migrationBuilder.RenameColumn(
                name: "word_template_mode",
                table: "users",
                newName: "words_template_mode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "words_template_mode",
                table: "users",
                newName: "word_template_mode");

            migrationBuilder.RenameColumn(
                name: "show_words_mode",
                table: "users",
                newName: "work_mode");
        }
    }
}
