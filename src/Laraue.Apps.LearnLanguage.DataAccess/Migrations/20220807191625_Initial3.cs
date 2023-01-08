using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_word_group_word_translations_word_groups_word_in_user_group",
                table: "word_group_word_translations");

            migrationBuilder.DropForeignKey(
                name: "fk_word_groups_words_word_id",
                table: "word_groups");

            migrationBuilder.DropIndex(
                name: "ix_word_groups_learn_state",
                table: "word_groups");

            migrationBuilder.DropIndex(
                name: "ix_word_groups_serial_number_user_id",
                table: "word_groups");

            migrationBuilder.DropIndex(
                name: "ix_word_groups_word_id",
                table: "word_groups");

            migrationBuilder.DropColumn(
                name: "learn_state",
                table: "word_groups");

            migrationBuilder.DropColumn(
                name: "word_id",
                table: "word_groups");

            migrationBuilder.RenameColumn(
                name: "word_in_user_group_id",
                table: "word_group_word_translations",
                newName: "word_group_id");

            migrationBuilder.RenameIndex(
                name: "ix_word_group_word_translations_word_in_user_group_id",
                table: "word_group_word_translations",
                newName: "ix_word_group_word_translations_word_group_id");

            migrationBuilder.AddColumn<byte>(
                name: "learn_state",
                table: "word_group_word_translations",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "ix_word_groups_serial_number",
                table: "word_groups",
                column: "serial_number");

            migrationBuilder.CreateIndex(
                name: "ix_word_group_word_translations_learn_state",
                table: "word_group_word_translations",
                column: "learn_state");

            migrationBuilder.AddForeignKey(
                name: "fk_word_group_word_translations_word_groups_word_group_id",
                table: "word_group_word_translations",
                column: "word_group_id",
                principalTable: "word_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_word_group_word_translations_word_groups_word_group_id",
                table: "word_group_word_translations");

            migrationBuilder.DropIndex(
                name: "ix_word_groups_serial_number",
                table: "word_groups");

            migrationBuilder.DropIndex(
                name: "ix_word_group_word_translations_learn_state",
                table: "word_group_word_translations");

            migrationBuilder.DropColumn(
                name: "learn_state",
                table: "word_group_word_translations");

            migrationBuilder.RenameColumn(
                name: "word_group_id",
                table: "word_group_word_translations",
                newName: "word_in_user_group_id");

            migrationBuilder.RenameIndex(
                name: "ix_word_group_word_translations_word_group_id",
                table: "word_group_word_translations",
                newName: "ix_word_group_word_translations_word_in_user_group_id");

            migrationBuilder.AddColumn<byte>(
                name: "learn_state",
                table: "word_groups",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<long>(
                name: "word_id",
                table: "word_groups",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_word_groups_learn_state",
                table: "word_groups",
                column: "learn_state");

            migrationBuilder.CreateIndex(
                name: "ix_word_groups_serial_number_user_id",
                table: "word_groups",
                columns: new[] { "serial_number", "user_id" });

            migrationBuilder.CreateIndex(
                name: "ix_word_groups_word_id",
                table: "word_groups",
                column: "word_id");

            migrationBuilder.AddForeignKey(
                name: "fk_word_group_word_translations_word_groups_word_in_user_group",
                table: "word_group_word_translations",
                column: "word_in_user_group_id",
                principalTable: "word_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_word_groups_words_word_id",
                table: "word_groups",
                column: "word_id",
                principalTable: "words",
                principalColumn: "id");
        }
    }
}
