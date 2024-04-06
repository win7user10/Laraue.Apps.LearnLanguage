using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.Apps.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_translation_states",
                table: "translation_states");

            migrationBuilder.AddPrimaryKey(
                name: "pk_translation_states",
                table: "translation_states",
                columns: new[] { "word_id", "meaning_id", "translation_id", "user_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_translation_states",
                table: "translation_states");

            migrationBuilder.AddPrimaryKey(
                name: "pk_translation_states",
                table: "translation_states",
                columns: new[] { "word_id", "meaning_id", "translation_id" });
        }
    }
}
