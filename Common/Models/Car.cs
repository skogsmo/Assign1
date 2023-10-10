using Common.Enums;
using Common.Interfaces;

namespace Common.Models
{
    public class Car : IVehicle
    {
        public string RegNo { get; set; }
        public string Make { get; set; }
        public int Odometer { get; set; }
        public int CostKm { get; set; }
        public VehicleType VehicleType { get; set; }
        public int CostDay { get; set; }
        public VehicleStatus VehicleStatus { get; set; }

        //public Car(string regNo, string make, int odometer, int costKm, VehicleType vType, int costDay, VehicleStatus vStatus)
        //{
        //    RegNo = regNo;
        //    Make = make;
        //    Odometer = odometer;
        //    CostKm = costKm;
        //    VehicleType = vType;
        //    CostDay = costDay;
        //    VehicleStatus = vStatus;
        //}

        public List<IVehicle> GetVehicles()
        {
            List<IVehicle> list = new List<IVehicle>();
            return list;
        }
    }
}
