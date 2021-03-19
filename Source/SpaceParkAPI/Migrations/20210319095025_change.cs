using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkAPI.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_ParkingRegistrations_ParkingRegistrationId",
                table: "ParkingSpots");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ParkingRegistrations_ParkingRegistrationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ParkingRegistrationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpots_ParkingRegistrationId",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "ParkingRegistrationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ParkingRegistrationId",
                table: "ParkingSpots");

            migrationBuilder.AddColumn<int>(
                name: "ParkingSpotsParkingSpotId",
                table: "ParkingRegistrations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ParkingRegistrations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRegistrations_ParkingSpotsParkingSpotId",
                table: "ParkingRegistrations",
                column: "ParkingSpotsParkingSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingRegistrations_UserId",
                table: "ParkingRegistrations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingRegistrations_ParkingSpots_ParkingSpotsParkingSpotId",
                table: "ParkingRegistrations",
                column: "ParkingSpotsParkingSpotId",
                principalTable: "ParkingSpots",
                principalColumn: "ParkingSpotId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingRegistrations_Users_UserId",
                table: "ParkingRegistrations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingRegistrations_ParkingSpots_ParkingSpotsParkingSpotId",
                table: "ParkingRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingRegistrations_Users_UserId",
                table: "ParkingRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_ParkingRegistrations_ParkingSpotsParkingSpotId",
                table: "ParkingRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_ParkingRegistrations_UserId",
                table: "ParkingRegistrations");

            migrationBuilder.DropColumn(
                name: "ParkingSpotsParkingSpotId",
                table: "ParkingRegistrations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ParkingRegistrations");

            migrationBuilder.AddColumn<int>(
                name: "ParkingRegistrationId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParkingRegistrationId",
                table: "ParkingSpots",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ParkingRegistrationId",
                table: "Users",
                column: "ParkingRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_ParkingRegistrationId",
                table: "ParkingSpots",
                column: "ParkingRegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_ParkingRegistrations_ParkingRegistrationId",
                table: "ParkingSpots",
                column: "ParkingRegistrationId",
                principalTable: "ParkingRegistrations",
                principalColumn: "ParkingRegistrationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ParkingRegistrations_ParkingRegistrationId",
                table: "Users",
                column: "ParkingRegistrationId",
                principalTable: "ParkingRegistrations",
                principalColumn: "ParkingRegistrationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
