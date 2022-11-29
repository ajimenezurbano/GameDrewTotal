using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDrewTotal.Migrations
{
    /// <inheritdoc />
    public partial class Identity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 11, 28, 7, 55, 27, 780, DateTimeKind.Utc).AddTicks(7113));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 11, 17, 8, 29, 16, 94, DateTimeKind.Utc).AddTicks(8053));
        }
    }
}
