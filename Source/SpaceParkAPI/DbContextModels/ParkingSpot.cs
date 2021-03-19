namespace SpaceParkAPI.DbContextModels
{
    public class ParkingSpot
    {
        public int ParkingSpotId { get; set; }
        public int Size { get; set; }
        public int Position { get; set; }
        public bool IsOccupied { get; set; }
    }
}