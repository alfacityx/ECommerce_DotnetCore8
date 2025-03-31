using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaret.Data.Migrations
{
    /// <inheritdoc />
    public partial class mak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 3, 17, 9, 5, 12, 440, DateTimeKind.Local).AddTicks(4225), new Guid("4f72eaa8-927d-4675-bbae-a86ff5848e10") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 3, 17, 9, 5, 12, 440, DateTimeKind.Local).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 3, 17, 9, 5, 12, 440, DateTimeKind.Local).AddTicks(6372));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 3, 16, 21, 24, 0, 740, DateTimeKind.Local).AddTicks(311), new Guid("dc2925f1-afa3-42c9-9273-18e772d94819") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 3, 16, 21, 24, 0, 740, DateTimeKind.Local).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 3, 16, 21, 24, 0, 740, DateTimeKind.Local).AddTicks(2221));
        }
    }
}
