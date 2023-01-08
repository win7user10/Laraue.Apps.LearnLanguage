using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "learn_state",
                table: "word_groups",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "ix_word_groups_learn_state",
                table: "word_groups",
                column: "learn_state");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_word_groups_learn_state",
                table: "word_groups");

            migrationBuilder.DropColumn(
                name: "learn_state",
                table: "word_groups");
        }
    }
}
