using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIsLearnedFlagStoringSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_marked",
                table: "word_translation_states",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.Sql("update word_translation_states set is_marked = learn_state & 2 != 0");
                
            migrationBuilder.DropColumn(
                name: "learn_state",
                table: "word_translation_states");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "learn_state",
                table: "word_translation_states",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
            
            migrationBuilder.DropColumn(
                name: "is_marked",
                table: "word_translation_states");
        }
    }
}
