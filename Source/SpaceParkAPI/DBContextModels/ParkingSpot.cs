using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceParkApi.DBContextModels
{
    class ParkingSpot
    {
        public int ParkingSpotID { get; set; }
        public int Length { get; set; }
        public int Position { get; set; }
        public bool IsOccupied { get; set; }

    }
}
