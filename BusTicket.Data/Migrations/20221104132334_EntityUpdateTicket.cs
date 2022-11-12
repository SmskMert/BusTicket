using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicket.Data.Migrations
{
    public partial class EntityUpdateTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PnrNo",
                table: "Tickets",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PnrNo",
                table: "Tickets");
        }
    }
}
