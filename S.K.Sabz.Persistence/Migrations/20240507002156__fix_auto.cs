using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S.K.Sabz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _fix_auto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2024, 5, 7, 3, 51, 54, 482, DateTimeKind.Local).AddTicks(5602));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2024, 5, 7, 3, 51, 54, 482, DateTimeKind.Local).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2024, 5, 7, 3, 51, 54, 482, DateTimeKind.Local).AddTicks(5661));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2024, 5, 6, 15, 58, 51, 662, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2024, 5, 6, 15, 58, 51, 662, DateTimeKind.Local).AddTicks(3714));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2024, 5, 6, 15, 58, 51, 662, DateTimeKind.Local).AddTicks(3728));
        }
    }
}
