using Common.Enums;
using Common.Interfaces;

namespace Common.Models
{
    public class Motorcycle : IVehicle
    {
        public string RegNo { get; set; }
        public string Make { get; set; }
        public int Odometer { get; set; }
        public int CostKm { get; set; }
        public VehicleType VehicleType { get; set; }
        public int CostDay { get; set; }
        public VehicleStatus VehicleStatus { get; set; }

        public List<IVehicle> GetVehicles()
        {
            List<IVehicle> list = new List<IVehicle>();
            return list;
        }
    }
}
