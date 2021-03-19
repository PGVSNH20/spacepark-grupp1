using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingRegistrations",
                columns: table => new
                {
                    ParkingRegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpaceShiptId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    ParkingFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingRegistrations", x => x.ParkingRegistrationId);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    ParkingSpotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    ParkingRegistrationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.ParkingSpotId);
                    table.ForeignKey(
                        name: "FK_ParkingSpots_ParkingRegistrations_ParkingRegistrationId",
                        column: x => x.ParkingRegistrationId,
                        principalTable: "ParkingRegistrations",
                        principalColumn: "ParkingRegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePlanet = table.Column<int>(type: "int", nullable: false),
                    ParkingRegistrationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_ParkingRegistrations_ParkingRegistrationId",
                        column: x => x.ParkingRegistrationId,
                        principalTable: "ParkingRegistrations",
                        principalColumn: "ParkingRegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_ParkingRegistrationId",
                table: "ParkingSpots",
                column: "ParkingRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ParkingRegistrationId",
                table: "Users",
                column: "ParkingRegistrationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ParkingRegistrations");
        }
    }
}
