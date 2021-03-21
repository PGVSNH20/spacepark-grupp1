using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class uppdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingRegistrations_ParkingSpots_ParkingSpotsParkingSpotId",
                table: "ParkingRegistrations");

            migrationBuilder.RenameColumn(
                name: "ParkingSpotsParkingSpotId",
                table: "ParkingRegistrations",
                newName: "ParkingSpotId");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingRegistrations_ParkingSpotsParkingSpotId",
                table: "ParkingRegistrations",
                newName: "IX_ParkingRegistrations_ParkingSpotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingRegistrations_ParkingSpots_ParkingSpotId",
                table: "ParkingRegistrations",
                column: "ParkingSpotId",
                principalTable: "ParkingSpots",
                principalColumn: "ParkingSpotId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingRegistrations_ParkingSpots_ParkingSpotId",
                table: "ParkingRegistrations");

            migrationBuilder.RenameColumn(
                name: "ParkingSpotId",
                table: "ParkingRegistrations",
                newName: "ParkingSpotsParkingSpotId");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingRegistrations_ParkingSpotId",
                table: "ParkingRegistrations",
                newName: "IX_ParkingRegistrations_ParkingSpotsParkingSpotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingRegistrations_ParkingSpots_ParkingSpotsParkingSpotId",
                table: "ParkingRegistrations",
                column: "ParkingSpotsParkingSpotId",
                principalTable: "ParkingSpots",
                principalColumn: "ParkingSpotId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
