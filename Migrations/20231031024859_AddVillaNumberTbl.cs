using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddVillaNumberTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNo);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 9, 48, 58, 944, DateTimeKind.Local).AddTicks(1390), new DateTime(2023, 10, 31, 9, 48, 58, 944, DateTimeKind.Local).AddTicks(1403) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 9, 48, 58, 944, DateTimeKind.Local).AddTicks(1405), new DateTime(2023, 10, 31, 9, 48, 58, 944, DateTimeKind.Local).AddTicks(1407) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 9, 48, 58, 944, DateTimeKind.Local).AddTicks(1409), new DateTime(2023, 10, 31, 9, 48, 58, 944, DateTimeKind.Local).AddTicks(1410) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 9, 48, 58, 944, DateTimeKind.Local).AddTicks(1411), new DateTime(2023, 10, 31, 9, 48, 58, 944, DateTimeKind.Local).AddTicks(1413) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 9, 48, 58, 944, DateTimeKind.Local).AddTicks(1414), new DateTime(2023, 10, 31, 9, 48, 58, 944, DateTimeKind.Local).AddTicks(1415) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 29, 20, 46, 13, 926, DateTimeKind.Local).AddTicks(8035), new DateTime(2023, 10, 29, 20, 46, 13, 926, DateTimeKind.Local).AddTicks(8063) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 29, 20, 46, 13, 926, DateTimeKind.Local).AddTicks(8066), new DateTime(2023, 10, 29, 20, 46, 13, 926, DateTimeKind.Local).AddTicks(8069) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 29, 20, 46, 13, 926, DateTimeKind.Local).AddTicks(8072), new DateTime(2023, 10, 29, 20, 46, 13, 926, DateTimeKind.Local).AddTicks(8075) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 29, 20, 46, 13, 926, DateTimeKind.Local).AddTicks(8078), new DateTime(2023, 10, 29, 20, 46, 13, 926, DateTimeKind.Local).AddTicks(8081) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 29, 20, 46, 13, 926, DateTimeKind.Local).AddTicks(8084), new DateTime(2023, 10, 29, 20, 46, 13, 926, DateTimeKind.Local).AddTicks(8103) });
        }
    }
}
