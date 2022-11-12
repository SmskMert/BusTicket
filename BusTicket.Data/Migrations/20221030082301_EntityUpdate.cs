using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicket.Data.Migrations
{
    public partial class EntityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MidLineOrder",
                table: "MidLines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 1,
                column: "MidLineOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 2,
                column: "MidLineOrder",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 3,
                column: "MidLineOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 4,
                column: "MidLineOrder",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 5,
                column: "MidLineOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 6,
                column: "MidLineOrder",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 7,
                column: "MidLineOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 8,
                column: "MidLineOrder",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 9,
                column: "MidLineOrder",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 10,
                column: "MidLineOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 11,
                column: "MidLineOrder",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 12,
                column: "MidLineOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 13,
                column: "MidLineOrder",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MidLines",
                keyColumn: "Id",
                keyValue: 14,
                column: "MidLineOrder",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MidLineOrder",
                table: "MidLines");
        }
    }
}
