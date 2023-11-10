using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsPortal.WebAppApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CategoryID", "Content", "EndDate", "ImageUrl", "IsTrending", "StartDate", "Subtitle", "Title" },
                values: new object[,]
                {
                    { "4", "3", "Apple has just announced the iPhone 14 Pro Max, featuring a revolutionary foldable display and an AI-powered camera system. This device promises to redefine the smartphone landscape with its innovative features and sleek design.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Game-Changer in Smartphone Technology", "Apple Unveils the Latest iPhone 14 Pro Max" },
                    { "5", "3", "Google's quantum computing team has achieved a major milestone, demonstrating a quantum computer capable of solving complex problems faster than ever before. This breakthrough has the potential to impact fields such as cryptography, drug discovery, and climate modeling.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Leap Toward Solving Complex Problems", "Google's Quantum Computing Breakthrough" },
                    { "6", "3", "In a historic move, the U.S. government has officially granted Tesla permission to deploy fully autonomous vehicles on public highways. Tesla's Autopilot system has reached a level of reliability and safety that is paving the way for a future with self-driving cars.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A New Era for Autonomous Vehicle", "Tesla's Self-Driving Cars Now Legal on U.S. Highways" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: "6");
        }
    }
}
