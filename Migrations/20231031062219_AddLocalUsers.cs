using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 13, 22, 19, 265, DateTimeKind.Local).AddTicks(6637), new DateTime(2023, 10, 31, 13, 22, 19, 265, DateTimeKind.Local).AddTicks(6651) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 13, 22, 19, 265, DateTimeKind.Local).AddTicks(6652), new DateTime(2023, 10, 31, 13, 22, 19, 265, DateTimeKind.Local).AddTicks(6654) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 13, 22, 19, 265, DateTimeKind.Local).AddTicks(6655), new DateTime(2023, 10, 31, 13, 22, 19, 265, DateTimeKind.Local).AddTicks(6657) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 13, 22, 19, 265, DateTimeKind.Local).AddTicks(6658), new DateTime(2023, 10, 31, 13, 22, 19, 265, DateTimeKind.Local).AddTicks(6659) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 13, 22, 19, 265, DateTimeKind.Local).AddTicks(6661), new DateTime(2023, 10, 31, 13, 22, 19, 265, DateTimeKind.Local).AddTicks(6662) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

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
    }
}
