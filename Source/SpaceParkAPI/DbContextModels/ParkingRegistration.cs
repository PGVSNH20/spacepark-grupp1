using System;
using System.Collections.Generic;

namespace SpaceParkAPI.DbContextModels
{
    public class ParkingRegistration
    {
        public int ParkingRegistrationId { get; set; }
        public User User { get; set; }
        public ParkingSpot ParkingSpots { get; set; }
        public int SpaceShiptId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsOccupied { get; set; }
        public decimal ParkingFee { get; set; }
    }
}