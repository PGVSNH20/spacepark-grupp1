using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkApi.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    ParkingSpotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.ParkingSpotID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeWorld = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ParkingRegistrations",
                columns: table => new
                {
                    ParkingRegistrationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    SpaceShipName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParkingStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParkingEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParkingFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    ParkingSpotID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingRegistrations", x => x.ParkingRegistrationID);
                    table.ForeignKey(
                        name: "FK_ParkingRegistrations_ParkingSpots_ParkingSpotID",
                        column: x => x.ParkingSpotID,
                        principalTable: "ParkingSpots",
                        principalColumn: "ParkingSpotID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingRegistrations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRegistrations_ParkingSpotID",
                table: "ParkingRegistrations",
                column: "ParkingSpotID");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRegistrations_UserId",
                table: "ParkingRegistrations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingRegistrations");

            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
