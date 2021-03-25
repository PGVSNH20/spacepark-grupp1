using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.DBContextModels
{
    public class ParkingRegistration
    {
        public int ParkingRegistrationID { get; set; }
        public User User { get; set; }
        public string SpaceShipName { get; set; }
        public DateTime ParkingStartTime { get; set; }
        public DateTime ParkingEndTime { get; set; }
        public decimal ParkingFee { get; set; }
        public bool IsPaid { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
    }
}