using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DropGroupsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "word_group_words");

            migrationBuilder.DropTable(
                name: "word_groups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "word_groups",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    serial_number = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_word_groups", x => x.id);
                    table.ForeignKey(
                        name: "fk_word_groups_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "word_group_words",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    word_group_id = table.Column<long>(type: "bigint", nullable: false),
                    word_translation_id = table.Column<long>(type: "bigint", nullable: false),
                    serial_number = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_word_group_words", x => x.id);
                    table.ForeignKey(
                        name: "fk_word_group_words_word_groups_word_group_id",
                        column: x => x.word_group_id,
                        principalTable: "word_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_word_group_words_word_translations_word_translation_id",
                        column: x => x.word_translation_id,
                        principalTable: "word_translations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_word_group_words_serial_number",
                table: "word_group_words",
                column: "serial_number");

            migrationBuilder.CreateIndex(
                name: "ix_word_group_words_word_group_id",
                table: "word_group_words",
                column: "word_group_id");

            migrationBuilder.CreateIndex(
                name: "ix_word_group_words_word_translation_id",
                table: "word_group_words",
                column: "word_translation_id");

            migrationBuilder.CreateIndex(
                name: "ix_word_groups_serial_number",
                table: "word_groups",
                column: "serial_number");

            migrationBuilder.CreateIndex(
                name: "ix_word_groups_user_id",
                table: "word_groups",
                column: "user_id");
        }
    }
}
