using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerAndPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCost = table.Column<int>(type: "int", nullable: false),
                    TravelCost = table.Column<int>(type: "int", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_VillaNumbers_VillaNo",
                        column: x => x.VillaNo,
                        principalTable: "VillaNumbers",
                        principalColumn: "VillaNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 2, 15, 1, 36, 553, DateTimeKind.Local).AddTicks(7509), new DateTime(2023, 11, 2, 15, 1, 36, 553, DateTimeKind.Local).AddTicks(7527) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 2, 15, 1, 36, 553, DateTimeKind.Local).AddTicks(7531), new DateTime(2023, 11, 2, 15, 1, 36, 553, DateTimeKind.Local).AddTicks(7533) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 2, 15, 1, 36, 553, DateTimeKind.Local).AddTicks(7537), new DateTime(2023, 11, 2, 15, 1, 36, 553, DateTimeKind.Local).AddTicks(7541) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 2, 15, 1, 36, 553, DateTimeKind.Local).AddTicks(7544), new DateTime(2023, 11, 2, 15, 1, 36, 553, DateTimeKind.Local).AddTicks(7546) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 2, 15, 1, 36, 553, DateTimeKind.Local).AddTicks(7547), new DateTime(2023, 11, 2, 15, 1, 36, 553, DateTimeKind.Local).AddTicks(7550) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PaymentID",
                table: "Customers",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_VillaNo",
                table: "Customers",
                column: "VillaNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Payments");

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
    }
}
