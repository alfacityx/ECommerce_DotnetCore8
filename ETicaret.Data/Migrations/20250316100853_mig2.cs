using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaret.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 3, 16, 13, 8, 53, 580, DateTimeKind.Local).AddTicks(4989), new Guid("57648146-f58a-4aac-9dfe-2f026ac58295") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 3, 16, 13, 8, 53, 580, DateTimeKind.Local).AddTicks(6798));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 3, 16, 13, 8, 53, 580, DateTimeKind.Local).AddTicks(6804));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 3, 15, 13, 54, 26, 619, DateTimeKind.Local).AddTicks(24), new Guid("f6313c18-ce83-48a3-82d5-5bb6d9936e23") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 3, 15, 13, 54, 26, 619, DateTimeKind.Local).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 3, 15, 13, 54, 26, 619, DateTimeKind.Local).AddTicks(1861));
        }
    }
}
