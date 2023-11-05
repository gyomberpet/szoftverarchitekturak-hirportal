using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPortal.WebAppApi.Migrations
{
    /// <inheritdoc />
    public partial class News_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPopular",
                table: "News",
                newName: "IsTrending");

            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtitle",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "IsTrending",
                table: "News",
                newName: "IsPopular");
        }
    }
}
