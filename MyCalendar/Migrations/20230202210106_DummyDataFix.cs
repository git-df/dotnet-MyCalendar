using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCalendar.Migrations
{
    /// <inheritdoc />
    public partial class DummyDataFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b120695-5261-4a24-89a1-a050944dc4f4"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "agnieszka", "kwiatkowska" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3715e326-6e29-43d7-bb77-af4440508186"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "nikola", "mazur" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("65dd2018-1cc6-4d0d-8f24-65909cd5d910"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "damian", "mróz" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9ce89f11-4d8b-4d78-98ee-4ef4640dfadf"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "cyprian", "jasiński" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d11283a-ac17-4201-ba97-0f6417ebc4ee"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "jan", "sobczak" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("acb3fd62-e723-44c5-835a-39c26cd218c3"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "anita", "chmielewska" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9bfab9e-fa7c-447f-a1c5-658f8b748bd0"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "natasza", "zalewska" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("beed33b1-14a4-4497-a4d4-46192fcd50be"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "norbert", "cieślak" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e20e44a0-27e3-4a95-9217-a898f54902c3"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "antoni", "górski" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fb8e707d-9a9d-40f6-9819-968add26204e"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "henryk", "adamski" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0b120695-5261-4a24-89a1-a050944dc4f4"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Agnieszka", "Kwiatkowska" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3715e326-6e29-43d7-bb77-af4440508186"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Nikola", "Mazur" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("65dd2018-1cc6-4d0d-8f24-65909cd5d910"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Damian", "Mróz" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9ce89f11-4d8b-4d78-98ee-4ef4640dfadf"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Cyprian", "Jasiński" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d11283a-ac17-4201-ba97-0f6417ebc4ee"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Jan", "Sobczak" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("acb3fd62-e723-44c5-835a-39c26cd218c3"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Anita", "Chmielewska" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9bfab9e-fa7c-447f-a1c5-658f8b748bd0"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Natasza", "Zalewska" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("beed33b1-14a4-4497-a4d4-46192fcd50be"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Norbert", "Cieślak" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e20e44a0-27e3-4a95-9217-a898f54902c3"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Antoni", "Górski" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fb8e707d-9a9d-40f6-9819-968add26204e"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Henryk", "Adamski" });
        }
    }
}
