using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsPortal.WebAppApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsTrending",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryID",
                table: "News",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "NewsCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Nature" },
                    { "2", "Health" },
                    { "3", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "IsAdmin", "Password", "UserName" },
                values: new object[,]
                {
                    { "1", "admin@kft.hu", true, "1234", "gipszjakab" },
                    { "2", "onion@nasa.gov", false, "1234", "shrek" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CategoryID", "Content", "EndDate", "ImageUrl", "IsTrending", "StartDate", "Subtitle", "Title" },
                values: new object[,]
                {
                    { "1", "1", "A magnitude 5.5 earthquake rattled Southern California, causing minor damage to some buildings. Authorities are urging residents to remain cautious and prepared for potential aftershocks.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Residents Urged to Stay Safe", "Earthquake Shakes California" },
                    { "2", "2", "A new variant of the COVID-19 virus has been identified in several countries. Health officials are closely monitoring the situation and advising continued vaccination efforts.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Health Officials Monitor Situation", "New COVID-19 Variant Detected" },
                    { "3", "3", "Tech enthusiasts rejoice as the leading tech company unveils its latest smartphone model, featuring a high-resolution camera and advanced AI capabilities.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Features High-Resolution Camera", "Tech Giant Launches New Smartphone" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryID",
                table: "News",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategories_CategoryID",
                table: "News",
                column: "CategoryID",
                principalTable: "NewsCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategories_CategoryID",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryID",
                table: "News");

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "News",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsTrending",
                table: "News",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "News",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryID",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
