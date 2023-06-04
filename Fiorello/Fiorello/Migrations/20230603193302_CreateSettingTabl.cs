using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Migrations
{
    public partial class CreateSettingTabl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 23, 33, 1, 784, DateTimeKind.Local).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 23, 33, 1, 784, DateTimeKind.Local).AddTicks(2554));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 23, 33, 1, 784, DateTimeKind.Local).AddTicks(2555));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 26, 12, 51, 0, 891, DateTimeKind.Local).AddTicks(3280));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 26, 12, 51, 0, 891, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 26, 12, 51, 0, 891, DateTimeKind.Local).AddTicks(3320));
        }
    }
}
