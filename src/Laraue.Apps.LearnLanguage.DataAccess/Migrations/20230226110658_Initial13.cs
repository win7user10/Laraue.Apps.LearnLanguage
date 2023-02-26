using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_word_translation_states_word_translation_id",
                table: "word_translation_states");

            migrationBuilder.CreateIndex(
                name: "ix_word_translation_states_word_translation_id_user_id",
                table: "word_translation_states",
                columns: new[] { "word_translation_id", "user_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_word_translation_states_word_translation_id_user_id",
                table: "word_translation_states");

            migrationBuilder.CreateIndex(
                name: "ix_word_translation_states_word_translation_id",
                table: "word_translation_states",
                column: "word_translation_id");
        }
    }
}
