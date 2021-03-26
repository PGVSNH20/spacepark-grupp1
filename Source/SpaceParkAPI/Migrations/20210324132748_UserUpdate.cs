using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceParkApi.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "HomeWorld",
                table: "Users",
                newName: "homeworld");
            migrationBuilder.Sql("TRUNCATE Table ParkingRegistrations");
            migrationBuilder.Sql(
                "ALTER TABLE ParkingRegistrations " +
                "DROP CONSTRAINT FK_ParkingRegistrations_ParkingSpots_ParkingSpotID");
            migrationBuilder.Sql("TRUNCATE Table ParkingSpots");
            migrationBuilder.Sql(
                "ALTER TABLE ParkingRegistrations " +
                "ADD CONSTRAINT FK_ParkingRegistrations_ParkingSpots_ParkingSpotID " +
                "FOREIGN KEY (ParkingSpotID) REFERENCES ParkingSpots(ParkingSpotID)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "homeworld",
                table: "Users",
                newName: "HomeWorld");
        }
    }
}