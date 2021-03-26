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
            migrationBuilder.Sql("INSERT INTO ParkingSpots (Length, Position, IsOccupied) " +
                "VALUES (100, 101, 0)," +
                " (100, 102, 0)," +
                " (100, 103, 0)," +
                " (100, 104, 0)," +
                " (100, 105, 0)," +
                " (500, 106, 0)," +
                " (500, 107, 0)," +
                " (500, 108, 0)," +
                " (1000, 109, 0)," +
                " (1000, 110, 0)");
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