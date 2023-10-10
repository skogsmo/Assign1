using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Data.Interfaces;

namespace Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IVehicle> _vehicles = new List<IVehicle>();
        readonly List<Customer> _customer = new List<Customer>();
        readonly List<Booking> _bookings = new List<Booking>();

        //Vehicle Propertys
        public string RegNo { get; set; }
        public string Make { get; set; }
        public int Odometer { get; set; }
        public int CostKm { get; set; }
        public VehicleType VehicleType { get; set; }
        public int CostDay { get; set; }
        public VehicleStatus VehicleStatus { get; set; }

        //Customer Propertys
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Ssn { get; set; }

        //Booking Porpertys
        public Car Car { get; set; }
        public Motorcycle Motorcycle { get; set; }
        public Customer Customer { get; set; }
        public int Kmrented { get; set; }
        public int Kmreturned { get; set; }
        public string Rented { get; set; }
        public string Returned { get; set; }
        public int Cost { get; set; }

        public CollectionData() => SeedData();

        void SeedData()
        {
            _vehicles.Add(new Car
            {
                RegNo = "ABC123",
                Make = "Volvo",
                Odometer = 1000,
                CostKm = 5,
                VehicleType = VehicleType.Combi,
                CostDay = 500,
                VehicleStatus = VehicleStatus.Booked
            });
            _vehicles.Add(new Car
            {
                RegNo = "FCZ154",
                Make = "Audi",
                Odometer = 2000,
                CostKm = 10,
                VehicleType = VehicleType.Sedan,
                CostDay = 750,
                VehicleStatus = VehicleStatus.Available
            });
            _vehicles.Add(new Motorcycle
            {
                RegNo = "QPS109",
                Make = "Ducati",
                Odometer = 4500,
                CostKm = 14,
                VehicleType = VehicleType.Motercyle,
                CostDay = 1000,
                VehicleStatus = VehicleStatus.Available
            });
            _vehicles.Add(new Car
            {
                RegNo = "DRS001",
                Make = "Wolkswagen",
                Odometer = 275000,
                CostKm = 4,
                VehicleType = VehicleType.Van,
                CostDay = 2,
                VehicleStatus = VehicleStatus.Booked
            });
            _customer.Add(new Customer { Fname = "Göran", Lname = "Karlsson", Ssn = "1234554" });
            _customer.Add(new Customer { Fname = "Jim", Lname = "Eriksson", Ssn = "5431432" });
            _bookings.Add(new Booking { Car = (Car)_vehicles[1], Customer = _customer[0], Kmrented = 1000, Kmreturned = 1400, Rented = "9/9/2023", Returned = "9/14/2023", Cost = 0, VehicleStatus = VehicleStatus.Closed });
            _bookings[0].Cost = CalcCost(_bookings[0]);
            _bookings.Add(new Booking { Car = (Car)_vehicles[0], Customer = _customer[1], Kmrented = 2000, Rented = "9/14/2023", VehicleStatus = VehicleStatus.Open });
        }


        public List<Customer> GetCustomers() => _customer;
        public List<Booking> GetBookings() => _bookings;
        public List<IVehicle> GetVehicles() => _vehicles;

        public int CalcCost(Booking booking)
        {
            var parseRent = DateTime.Parse(booking.Rented);
            var parseReturn = DateTime.Parse(booking.Returned);
            var daysRent = parseReturn.Day - parseRent.Day;

            var costOverPeriod = booking.Car.CostDay * daysRent;
            var extraCostPerKm = (booking.Kmreturned - booking.Kmrented) * booking.Car.CostKm;

            return costOverPeriod + extraCostPerKm;
        }
    }
}
