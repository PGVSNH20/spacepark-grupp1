using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class uppdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingRegistrations",
                columns: table => new
                {
                    ParkingRegistrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ParkingSpotsParkingSpotId = table.Column<int>(type: "int", nullable: true),
                    SpaceShiptId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    ParkingFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingRegistrations", x => x.ParkingRegistrationId);
                    table.ForeignKey(
                        name: "FK_ParkingRegistrations_ParkingSpots_ParkingSpotsParkingSpotId",
                        column: x => x.ParkingSpotsParkingSpotId,
                        principalTable: "ParkingSpots",
                        principalColumn: "ParkingSpotId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingRegistrations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRegistrations_ParkingSpotsParkingSpotId",
                table: "ParkingRegistrations",
                column: "ParkingSpotsParkingSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRegistrations_UserId",
                table: "ParkingRegistrations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingRegistrations");
        }
    }
}
