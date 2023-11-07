using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPortal.WebAppApi.Migrations
{
    /// <inheritdoc />
    public partial class StoreImageAsByteArray : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "News");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "News",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "1",
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "2",
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "3",
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "4",
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "5",
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "6",
                column: "Image",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "1",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "2",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "3",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "4",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "5",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "6",
                column: "ImageUrl",
                value: null);
        }
    }
}
