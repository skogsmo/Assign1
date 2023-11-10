using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Data.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IVehicle> _vehicles = new List<IVehicle>();
        readonly List<ICustomer> _customer = new List<ICustomer>();
        readonly List<IBooking> _bookings = new List<IBooking>();

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
        public int Id { get; set; }

        //Booking Porpertys
        public Vehicle Car { get; set; }
        public Motorcycle Motorcycle { get; set; }
        public Customer Customer { get; set; }
        public int Kmrented { get; set; }
        public int Kmreturned { get; set; }
        public DateTime Rented { get; set; }
        public DateTime? Returned { get; set; }
        public int Cost { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;

        public int NextPersonId => _customer.Count.Equals(0) ? 1 : _customer.Max(b => b.Id) + 1;

        public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

        public CollectionData() => SeedData();

        void SeedData()
        {
            _vehicles.Add(new Vehicle
            {
                RegNo = "ABC123",
                Make = "Volvo",
                Odometer = 1000,
                CostKm = 5,
                VehicleType = VehicleType.Combi,
                CostDay = 500,
                VehicleStatus = VehicleStatus.Booked,
                Id = 1
            });
            _vehicles.Add(new Vehicle
            {
                RegNo = "FCZ154",
                Make = "Audi",
                Odometer = 2000,
                CostKm = 10,
                VehicleType = VehicleType.Sedan,
                CostDay = 750,
                VehicleStatus = VehicleStatus.Available,
                Id = 2
            });
            _vehicles.Add(new Vehicle
            {
                RegNo = "QPS109",
                Make = "Ducati",
                Odometer = 4500,
                CostKm = 14,
                VehicleType = VehicleType.Motercyle,
                CostDay = 1000,
                VehicleStatus = VehicleStatus.Available,
                Id = 3
            });
            _vehicles.Add(new Vehicle
            {
                RegNo = "DRS001",
                Make = "Wolkswagen",
                Odometer = 275000,
                CostKm = 4,
                VehicleType = VehicleType.Van,
                CostDay = 2,
                VehicleStatus = VehicleStatus.Available,
                Id = 4
            });
            _customer.Add(new Customer { Fname = "Göran", Lname = "Karlsson", Ssn = "1234554", Id = 1 });
            _customer.Add(new Customer { Fname = "Jim", Lname = "Eriksson", Ssn = "5431432", Id = 2 });
            _bookings.Add(new Booking { Car = (Vehicle)_vehicles[1], Customer = (Customer)_customer[0], Kmrented = 1000, Kmreturned = 1400, Rented = new DateTime(2020, 09, 01), Returned = new DateTime(2020, 09, 20), Cost = 0, BookingStatus = BookingStatus.Closed, Id = 1 });
            _bookings[0].Cost = CalcCost(_bookings[0].Rented, _bookings[0].Returned, _bookings[0].Car.CostDay, _bookings[0].Kmreturned, _bookings[0].Kmrented, _bookings[0].Car.CostKm);
            _bookings.Add(new Booking { Car = (Vehicle)_vehicles[0], Customer = (Customer)_customer[1], Kmrented = 2000, Rented = new DateTime(2023, 09, 01), Returned = null, BookingStatus = BookingStatus.Open, Id = 2 });
        }

        public List<ICustomer> GetCustomers() => _customer;
        public List<IBooking> GetBookings() => _bookings;
        public List<IVehicle> GetVehicles() => _vehicles;
        public int CalcCost(DateTime rented, DateTime? returned, int costDay, int kmReturned, int kmRented, int costKm)
        {
            var parseRent = rented;
            var parseReturn = returned;
            var daysRent = parseReturn?.Day - parseRent.Day;

            var costOverPeriod = costDay * daysRent;
            var extraCostPerKm = (kmReturned - kmRented) * costKm;

            return (int)(costOverPeriod + extraCostPerKm);
        }

        public List<T> Get<T>(Expression<Func<T, bool>>? expression) 
        {
            var list = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.FieldType == typeof(List<T>)).GetValue(this) as List<T>;
            if (expression != null)
            {
                try
                {
                    return list.Where(expression.Compile()).ToList();
                }
                catch
                {
                    throw;
                }
            }
            return list ?? new List<T>();
        }

        public T? Single<T>(Expression<Func<T, bool>>? expression)
        {
            var list = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.FieldType == typeof(List<T>)).GetValue(this) as List<T>;
            if (expression != null)
            {
                try
                {
                    return list.SingleOrDefault(expression.Compile());
                }
                catch
                {
                    throw;
                }
            }
            return default;
        }

        public void Add<T>(T item)
        {
            var test = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.FieldType == typeof(List<T>)).GetValue(this) as List<T>;
            test.Add(item);
        }

        public void RentVehicle(int vehicleId, int customerId)
        {
            DateTime now = DateTime.Now;
            Vehicle vehicle = (Vehicle)_vehicles.FirstOrDefault(v => v.Id == vehicleId);
            Customer customer = (Customer)_customer.FirstOrDefault(c => c.Id == customerId);

            if (vehicle == null || customer == null) 
            {
                throw new ArgumentException("Invalid Ids");
            }
            _bookings.Add(new Booking
            {
                Car = vehicle,
                Customer = customer,
                Kmrented = vehicle.Odometer,
                Rented = now,
                Id = NextBookingId
            });
            vehicle.VehicleStatus = VehicleStatus.Booked;
        }

        public void ReturnVehicle(int vehicleId, int customerId, int input)
        {
            var booking = GetBookings();
            var openBooking = booking.Where(booking => booking.Car.Id == vehicleId && booking.BookingStatus == BookingStatus.Open).Single();
            openBooking.Car.VehicleStatus = VehicleStatus.Available;
            openBooking.Returned = DateTime.Now;
            openBooking.Kmreturned = openBooking.Kmrented + input;
            openBooking.Cost = CalcCost(openBooking.Rented, openBooking.Returned, openBooking.Car.CostDay, openBooking.Kmreturned, openBooking.Kmrented, openBooking.Car.CostKm);
            openBooking.BookingStatus = BookingStatus.Closed;

        }
    }
}