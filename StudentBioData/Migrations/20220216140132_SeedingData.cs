using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentBioData.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "Department", "FirstName", "LGA", "LastName", "Level", "MiddleName", "Nationality", "StateOfOrigin" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015), "Computer Science", "Wale", "Igueben", "Adewale", "400", "Olawale", "Nigeria", "Edo" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "Department", "FirstName", "LGA", "LastName", "Level", "MiddleName", "Nationality", "StateOfOrigin" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015), "Computer Science", "Awele", "Ika North", "Uzordinma", "400", "Princess", "Nigeria", "Delta" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
