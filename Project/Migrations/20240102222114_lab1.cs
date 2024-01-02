using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class lab1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Airline_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Plane_quont = table.Column<int>(type: "int", nullable: false),
                    Route_quont = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.Airline_id);
                });

            migrationBuilder.CreateTable(
                name: "Airport_s",
                columns: table => new
                {
                    Airport_Id = table.Column<int>(type: "int", maxLength: 6, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Workers_quont = table.Column<int>(type: "int", nullable: false),
                    Passengers_quont = table.Column<int>(type: "int", nullable: false),
                    Planes_quont = table.Column<int>(type: "int", nullable: false),
                    Gates_quont = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport_s", x => x.Airport_Id);
                    table.UniqueConstraint("AK_Airport_s_Name_Address", x => new { x.Name, x.Address });
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "int", maxLength: 6, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerId);
                    table.CheckConstraint("Age", "Age > 0 AND Age < 100");
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    PlaneId = table.Column<int>(type: "int", maxLength: 6, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirlineIdAirline_id = table.Column<int>(type: "int", nullable: true),
                    Airline_id = table.Column<int>(type: "int", nullable: true),
                    Airline_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flight_Id = table.Column<int>(type: "int", nullable: false),
                    Max_Plane_Quont = table.Column<int>(type: "int", nullable: false),
                    Pilote_Quont = table.Column<int>(type: "int", nullable: false),
                    Flight_Attendant_Quont = table.Column<int>(type: "int", nullable: false),
                    Carrying_Capacity = table.Column<double>(type: "float", nullable: false),
                    Fuel_Consumption = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.PlaneId);
                    table.ForeignKey(
                        name: "FK_Planes_Airlines_AirlineIdAirline_id",
                        column: x => x.AirlineIdAirline_id,
                        principalTable: "Airlines",
                        principalColumn: "Airline_id");
                    table.ForeignKey(
                        name: "FK_Planes_Airlines_Airline_id",
                        column: x => x.Airline_id,
                        principalTable: "Airlines",
                        principalColumn: "Airline_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    Airport_ID_1 = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    Airport_ID_2 = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    Airline_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Airline_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                    table.ForeignKey(
                        name: "FK_Routes_Airlines_Airline_id",
                        column: x => x.Airline_id,
                        principalTable: "Airlines",
                        principalColumn: "Airline_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routes_Airport_s_Airport_ID_1",
                        column: x => x.Airport_ID_1,
                        principalTable: "Airport_s",
                        principalColumn: "Airport_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routes_Airport_s_Airport_ID_2",
                        column: x => x.Airport_ID_2,
                        principalTable: "Airport_s",
                        principalColumn: "Airport_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Surname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    AirportId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirportsAirport_Id = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => new { x.WorkerId, x.Surname });
                    table.ForeignKey(
                        name: "FK_Workers_Airport_s_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airport_s",
                        principalColumn: "Airport_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workers_Airport_s_AirportsAirport_Id",
                        column: x => x.AirportsAirport_Id,
                        principalTable: "Airport_s",
                        principalColumn: "Airport_Id");
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", maxLength: 6, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plane_Id = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    Route_Id = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    First = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Second = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gate_Number = table.Column<int>(type: "int", nullable: false),
                    Pasengers_Quont = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Planes_Plane_Id",
                        column: x => x.Plane_Id,
                        principalTable: "Planes",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Routes_Route_Id",
                        column: x => x.Route_Id,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", maxLength: 6, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flight_Id = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    Passenger_Doc_Id = table.Column<int>(type: "int", nullable: false),
                    Baggage_Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Flights_Flight_Id",
                        column: x => x.Flight_Id,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_Passenger_Doc_Id",
                        column: x => x.Passenger_Doc_Id,
                        principalTable: "Passengers",
                        principalColumn: "PassengerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "Airline_id", "AirlineName", "Plane_quont", "Route_quont" },
                values: new object[,]
                {
                    { 1, "Airline1", 1, 1 },
                    { 2, "Airline2", 2, 1 },
                    { 3, "Airline3", 3, 3 },
                    { 4, "Airline4", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "Age", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, 20, "Passenger1", "Surname1" },
                    { 2, 20, "Passenger2", "Surname2" },
                    { 3, 21, "Passenger3", "Surname3" },
                    { 4, 25, "Passenger4", "Surname4" },
                    { 5, 30, "Passenger5", "Surname5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_Plane_Id",
                table: "Flights",
                column: "Plane_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_Route_Id",
                table: "Flights",
                column: "Route_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_Airline_id",
                table: "Planes",
                column: "Airline_id");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_AirlineIdAirline_id",
                table: "Planes",
                column: "AirlineIdAirline_id");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Airline_id",
                table: "Routes",
                column: "Airline_id");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Airport_ID_1",
                table: "Routes",
                column: "Airport_ID_1");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Airport_ID_2",
                table: "Routes",
                column: "Airport_ID_2");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Flight_Id",
                table: "Tickets",
                column: "Flight_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Passenger_Doc_Id",
                table: "Tickets",
                column: "Passenger_Doc_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_AirportId",
                table: "Workers",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_AirportsAirport_Id",
                table: "Workers",
                column: "AirportsAirport_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Airport_s");
        }
    }
}
