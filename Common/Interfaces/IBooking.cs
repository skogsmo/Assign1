using Common.Enums;
using Common.Models;

namespace Common.Interfaces
{
    public interface IBooking
    {
        public Car Car { get; set; }
        public Motorcycle Motorcycle { get; set; }
        public Customer Customer { get; set; }
        public int Kmrented { get; set; }
        public int Kmreturned { get; set; }
        public string Rented { get; set; }
        public string Returned { get; set; }
        public int Cost { get; set; }
        public VehicleStatus VehicleStatus { get; set; }

        List<Booking> GetBookings();
    }
}
