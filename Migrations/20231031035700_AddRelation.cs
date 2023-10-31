using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "VillaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate", "VillaID" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8244), new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8246), 0 });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate", "VillaID" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8247), new DateTime(2023, 10, 31, 10, 57, 0, 99, DateTimeKind.Local).AddTicks(8248), 0 });

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

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers",
                column: "VillaID",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2788), new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2790) });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2792), new DateTime(2023, 10, 31, 10, 24, 21, 612, DateTimeKind.Local).AddTicks(2793) });

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
    }
}
