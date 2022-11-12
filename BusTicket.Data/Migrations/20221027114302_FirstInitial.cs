using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusTicket.Data.Migrations
{
    public partial class FirstInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    HasWifi = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasUSB = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasSeatScreen = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FName = table.Column<string>(type: "TEXT", nullable: true),
                    LName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<string>(type: "TEXT", nullable: true),
                    Contact = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Contact = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartingPoint = table.Column<string>(type: "TEXT", nullable: true),
                    Destination = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusId = table.Column<int>(type: "INTEGER", nullable: false),
                    DriverId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripDetails_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripDetails_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TripDetails_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MidLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartingPoint = table.Column<string>(type: "TEXT", nullable: true),
                    Destination = table.Column<string>(type: "TEXT", nullable: true),
                    LineId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MidLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MidLines_Lines_LineId",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MidLineId = table.Column<int>(type: "INTEGER", nullable: false),
                    TripDetailId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduleDate = table.Column<string>(type: "TEXT", nullable: true),
                    DepartureTime = table.Column<string>(type: "TEXT", nullable: true),
                    ArrivalTime = table.Column<string>(type: "TEXT", nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    FareAmount = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_MidLines_MidLineId",
                        column: x => x.MidLineId,
                        principalTable: "MidLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_TripDetails_TripDetailId",
                        column: x => x.TripDetailId,
                        principalTable: "TripDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SeatNo = table.Column<int>(type: "INTEGER", nullable: false),
                    IsBooked = table.Column<bool>(type: "INTEGER", nullable: false),
                    TripId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "Capacity", "HasSeatScreen", "HasUSB", "HasWifi" },
                values: new object[] { 1, 10, false, false, true });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "Capacity", "HasSeatScreen", "HasUSB", "HasWifi" },
                values: new object[] { 2, 15, false, true, false });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "Capacity", "HasSeatScreen", "HasUSB", "HasWifi" },
                values: new object[] { 3, 20, true, true, true });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Metro Turizm" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Kamil Koç" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Lüks Artvin" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "Contact", "Email", "FName", "Gender", "LName" },
                values: new object[] { 1, "26", "05556667770", "mertsimsek@gmail.com", "Mert", "Male", "Simsek" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "Contact", "Email", "FName", "Gender", "LName" },
                values: new object[] { 2, "27", "05556667771", "cansunur@gmail.com", "Cansu Nur", "Female", "Ürek" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "Contact", "Email", "FName", "Gender", "LName" },
                values: new object[] { 3, "35", "05556667772", "ali@gmail.com", "Ali", "Male", "Cesur" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "Contact", "Email", "FName", "Gender", "LName" },
                values: new object[] { 4, "40", "05556667773", "ayse@gmail.com", "Ayşe", "Female", "Yavaş" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Contact", "Name" },
                values: new object[] { 1, "+905556668880", "Niyazi Hızlı" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Contact", "Name" },
                values: new object[] { 2, "+905556668881", "Murat Seyrek" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Contact", "Name" },
                values: new object[] { 3, "+905556668882", "Berk Entel" });

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "Destination", "StartingPoint" },
                values: new object[] { 1, "Adana", "İstanbul" });

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "Destination", "StartingPoint" },
                values: new object[] { 2, "Hatay", "Rize" });

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "Destination", "StartingPoint" },
                values: new object[] { 3, "Antalya", "Sinop" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 1, "Gebze", 1, "İstanbul" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 2, "Sakarya", 1, "Gebze" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 3, "Ankara", 1, "Sakarya" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 4, "Adana", 1, "Ankara" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 5, "Trabzon", 2, "Rize" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 6, "Erzincan", 2, "Trabzon" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 7, "Sivas", 2, "Erzincan" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 8, "Gaziantep", 2, "Sivas" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 9, "Hatay", 2, "Gaziantep" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 10, "Kastamonu", 3, "Sinop" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 11, "Karabük", 3, "Kastamonu" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 12, "Afyon", 3, "Karabük" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 13, "Burdur", 3, "Afyon" });

            migrationBuilder.InsertData(
                table: "MidLines",
                columns: new[] { "Id", "Destination", "LineId", "StartingPoint" },
                values: new object[] { 14, "Antalya", 3, "Burdur" });

            migrationBuilder.InsertData(
                table: "TripDetails",
                columns: new[] { "Id", "BusId", "CompanyId", "DriverId" },
                values: new object[] { 1, 1, null, 1 });

            migrationBuilder.InsertData(
                table: "TripDetails",
                columns: new[] { "Id", "BusId", "CompanyId", "DriverId" },
                values: new object[] { 2, 1, null, 1 });

            migrationBuilder.InsertData(
                table: "TripDetails",
                columns: new[] { "Id", "BusId", "CompanyId", "DriverId" },
                values: new object[] { 3, 1, null, 1 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 1, "14:00", "11:30", 50m, 1, null, "01.11.2022", 1 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 2, "15:20", "14:00", null, 2, null, "01.11.2022", 1 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 3, "21:30", "15:20", 120m, 3, null, "01.11.2022", 1 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 4, "21:30", "15:20", 150m, 4, null, "01.11.2022", 1 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 5, "21:30", "15:20", 70m, 5, null, "01.11.2022", 1 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 6, "21:30", "15:20", 150m, 6, null, "01.11.2022", 2 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 7, "21:30", "15:20", 110m, 7, null, "01.11.2022", 2 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 8, "21:30", "15:20", 60m, 8, null, "01.11.2022", 2 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 9, "21:30", "15:20", 90m, 9, null, "01.11.2022", 2 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 10, "21:30", "15:20", 40m, 10, null, "01.11.2022", 3 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 11, "21:30", "15:20", 75m, 11, null, "01.11.2022", 3 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 12, "21:30", "15:20", 115m, 12, null, "01.11.2022", 3 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 13, "21:30", "15:20", 120m, 13, null, "01.11.2022", 3 });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "FareAmount", "MidLineId", "Remarks", "ScheduleDate", "TripDetailId" },
                values: new object[] { 14, "21:30", "15:20", 60m, 14, null, "01.11.2022", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_MidLines_LineId",
                table: "MidLines",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerId",
                table: "Tickets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TripId",
                table: "Tickets",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetails_BusId",
                table: "TripDetails",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetails_CompanyId",
                table: "TripDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetails_DriverId",
                table: "TripDetails",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_MidLineId",
                table: "Trips",
                column: "MidLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TripDetailId",
                table: "Trips",
                column: "TripDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "MidLines");

            migrationBuilder.DropTable(
                name: "TripDetails");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
