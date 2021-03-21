using System;
using System.Collections.Generic;

namespace SpaceParkAPI.DbContextModels
{
    public class ParkingRegistration
    {
        public Guid ParkingRegistrationId { get; set; }
        public User User { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
        public int StarshipId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsOccupied { get; set; }
        public decimal ParkingFee { get; set; }
    }
}