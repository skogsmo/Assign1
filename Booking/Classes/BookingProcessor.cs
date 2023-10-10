using Common.Interfaces;
using Common.Models;
using Data.Interfaces;

namespace Business.Classes
{
    public class BookingProcessor
    {
        private readonly IData _db;

        public BookingProcessor(IData db) => _db = db;

        public List<Customer> GetCustomers() => _db.GetCustomers();
        public List<Vehicle> GetVehicles() => _db.GetVehicles();
        public List<Booking> GetBookings() => _db.GetBookings();

    }
}
