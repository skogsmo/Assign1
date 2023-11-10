using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Data.Interfaces;

namespace Business.Classes
{
    public class BookingProcessor
    {
        public string input1 { get; set; }
        public string input2 { get; set; }
        public string input3 { get; set; }
        public int? input4 { get; set; }
        public int? input5 { get; set; }
        public VehicleType input6 { get; set; }
        public int? input7 { get; set; }
        public int CustomerId { get; set; }
        public int distance { get; set; }
        public string LockTable = string.Empty;
        public bool IsTableLocked = false;

        private readonly IData _db;
        
        public BookingProcessor(IData db) => _db = db;

        public List<ICustomer> GetCustomers() => _db.Get<ICustomer>(null);
        public List<IVehicle> GetVehicles() => _db.Get<IVehicle>(null);
        public List<IBooking> GetBookings() => _db.Get<IBooking>(null);
        public string[] VehicleStatusName => _db.VehicleStatusName;
        public string[] VehicleTypeName => _db.VehicleTypeName;

        public void CustomerButton()
        {
            AddCustomer(input1, input2, input3);

            input1 = string.Empty;
            input2 = string.Empty;
            input3 = string.Empty;
        }

        public void VehicleButton()
        {
            AddVehicle(input1, input2, input4, input5, input6, input7);

            input1 = string.Empty;
            input2 = string.Empty;
        }

        public async Task RentButton(int vId, int cId)
        {
            IsTableLocked = true;
            LockTable = "pointer-events: none; filter: grayscale(60%); opacity: 0.5; ";
            await Task.Delay(TimeSpan.FromSeconds(5));
            LockTable = "pointer-events: default; filter: grayscale(default); opacity: default;";
            await Task.Run(() => _db.RentVehicle(vId, cId));
            IsTableLocked = false;
        }

        public void RenturnButton(int vId, int cId, int input)
        {
            _db.ReturnVehicle(vId, cId, input);
        }

        public void AddCustomer(string firstName, string lastName, string socialSecurityNumber)
        {
            var customer = _db.Get<Customer>(null);
            customer.Add(new Customer
            {
                Fname = firstName,
                Lname = lastName,
                Ssn = socialSecurityNumber,
                Id = _db.NextPersonId
            });
        }

        public void AddVehicle(string regNo, string make, int? odometer, int? costKm, VehicleType vType, int? costDay)
        {
            var vehicle = _db.Get<IVehicle>(null);
            if(odometer != null && costKm != null && costDay != null)
            {
                vehicle.Add(new Vehicle
                {
                    RegNo = regNo,
                    Make = make,
                    Odometer = (int)odometer,
                    CostKm = (int)costKm,
                    VehicleType = vType,
                    CostDay = (int)costDay,
                    VehicleStatus = 0,
                    Id = _db.NextVehicleId
                });
            }
            return;
        }

        


    }
}
