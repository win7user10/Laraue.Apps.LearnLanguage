using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laraue.LearnLanguage.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "telegram_user_name",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.Sql(@"update ""users"" set telegram_user_name = REPLACE(user_name, 'tg_', '')");
            migrationBuilder.Sql(@"update ""users"" set user_name = 'tg_' || telegram_id");
            migrationBuilder.Sql(@"update ""users"" set normalized_user_name = 'TG_' || telegram_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"update ""users"" set user_name = 'tg_' || telegram_user_name");
            migrationBuilder.Sql(@"update ""users"" set normalized_user_name = UPPER('tg_' || telegram_user_name)");
            
            migrationBuilder.DropColumn(
                name: "telegram_user_name",
                table: "users");
        }
    }
}
