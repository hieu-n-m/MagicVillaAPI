using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaNumberTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "VillaNo", "CreatedDate", "Details", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2788), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2790) },
                    { 2, new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2792), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2793) }
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2600), new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2612) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2614), new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2616) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2617), new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2618) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2620), new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2621) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2623), new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2625) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 2);

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
    }
}
