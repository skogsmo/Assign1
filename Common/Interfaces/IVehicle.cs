﻿using Common.Enums;
using Common.Models;

namespace Common.Interfaces
{
    public interface IVehicle
    {
        public string RegNo { get; set; }
        public string Make { get; set; }
        public int Odometer { get; set; }
        public int CostKm { get; set; }
        public VehicleType VehicleType { get; set; }
        public int CostDay { get; set; }
        public VehicleStatus VehicleStatus { get; set; }

        List<IVehicle> GetVehicles();
    }
}
