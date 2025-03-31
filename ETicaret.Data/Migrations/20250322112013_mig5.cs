using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaret.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeliveryAdress",
                table: "Adresses",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsBillingAdress",
                table: "Adresses",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 3, 22, 14, 20, 13, 595, DateTimeKind.Local).AddTicks(2778), new Guid("9db0a917-543e-4a6f-9977-04bb0c472749") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 3, 22, 14, 20, 13, 595, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 3, 22, 14, 20, 13, 595, DateTimeKind.Local).AddTicks(4708));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsDeliveryAdress",
                table: "Adresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "IsBillingAdress",
                table: "Adresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 3, 22, 14, 16, 12, 239, DateTimeKind.Local).AddTicks(4216), new Guid("4914b77e-5def-4d55-ad75-3775f069d740") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 3, 22, 14, 16, 12, 239, DateTimeKind.Local).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 3, 22, 14, 16, 12, 239, DateTimeKind.Local).AddTicks(6161));
        }
    }
}
