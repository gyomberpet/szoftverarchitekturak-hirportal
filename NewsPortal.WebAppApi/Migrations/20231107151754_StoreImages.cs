using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPortal.WebAppApi.Migrations
{
    /// <inheritdoc />
    public partial class StoreImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "News");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "News",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "1",
                column: "ImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "2",
                column: "ImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "3",
                column: "ImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "4",
                column: "ImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "5",
                column: "ImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: "6",
                column: "ImageId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_News_ImageId",
                table: "News",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Images_ImageId",
                table: "News",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Images_ImageId",
                table: "News");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_News_ImageId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ImageId",
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
    }
}
