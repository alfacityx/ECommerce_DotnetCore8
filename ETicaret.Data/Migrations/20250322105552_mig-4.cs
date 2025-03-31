using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaret.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    City = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    District = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    OpenAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsBillingAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeliveryAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdressGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 3, 22, 13, 55, 51, 447, DateTimeKind.Local).AddTicks(4645), new Guid("b12b13fe-32e4-4c1f-a738-b40b6fef08c7") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 3, 22, 13, 55, 51, 447, DateTimeKind.Local).AddTicks(6561));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 3, 22, 13, 55, 51, 447, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_AppUserId",
                table: "Adresses",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

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
    }
}
