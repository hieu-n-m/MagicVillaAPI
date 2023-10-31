using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeedDataFromVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2023, 10, 31, 11, 2, 2, 927, DateTimeKind.Local).AddTicks(1388), new DateTime(2023, 10, 31, 11, 2, 2, 927, DateTimeKind.Local).AddTicks(1402) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 11, 2, 2, 927, DateTimeKind.Local).AddTicks(1404), new DateTime(2023, 10, 31, 11, 2, 2, 927, DateTimeKind.Local).AddTicks(1406) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 11, 2, 2, 927, DateTimeKind.Local).AddTicks(1407), new DateTime(2023, 10, 31, 11, 2, 2, 927, DateTimeKind.Local).AddTicks(1412) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 11, 2, 2, 927, DateTimeKind.Local).AddTicks(1413), new DateTime(2023, 10, 31, 11, 2, 2, 927, DateTimeKind.Local).AddTicks(1414) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 11, 2, 2, 927, DateTimeKind.Local).AddTicks(1415), new DateTime(2023, 10, 31, 11, 2, 2, 927, DateTimeKind.Local).AddTicks(1417) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "VillaNo", "CreatedDate", "Details", "UpdatedDate", "VillaID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8244), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8246), 0 },
                    { 2, new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8247), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8248), 0 }
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8042), new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8054) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8056), new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8058) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8059), new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8062), new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8063) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8064), new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8066) });
        }
    }
}
