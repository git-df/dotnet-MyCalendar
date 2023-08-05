using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCalendar.Migrations
{
    /// <inheritdoc />
    public partial class EndEventDateAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndEventDate",
                table: "Events",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndEventDate",
                value: new DateTime(2000, 12, 12, 1, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "EndEventDate",
                value: new DateTime(2024, 6, 1, 1, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "EndEventDate",
                value: new DateTime(2000, 1, 10, 1, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "EndEventDate",
                value: new DateTime(2000, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "EndEventDate",
                value: new DateTime(2000, 1, 10, 1, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                column: "EndEventDate",
                value: new DateTime(2025, 8, 15, 1, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndEventDate",
                table: "Events");
        }
    }
}
