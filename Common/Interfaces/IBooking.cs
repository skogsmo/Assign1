using Common.Enums;
using Common.Models;

namespace Common.Interfaces
{
    public interface IBooking
    {
        public Vehicle Car { get; set; }
        public Motorcycle Motorcycle { get; set; }
        public Customer Customer { get; set; }
        public int Kmrented { get; set; }
        public int Kmreturned { get; set; }
        public DateTime Rented { get; set; }
        public DateTime? Returned { get; set; }
        public int Cost { get; set; }
        public BookingStatus BookingStatus { get; set; } 
        public int Id { get; set; }

    }
}
