using Common.Enums;
using Common.Interfaces;

namespace Common.Models
{
    public class Booking : IBooking
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

        //public Booking(Car car, Customer cust, int kmRented, int kmReturned, string rent, string returned, int cost, VehicleStatus vStatus)
        //{
        //    this.Car = car;
        //    this.Customer = cust;
        //    this.Kmrented = kmRented;
        //    this.Kmreturned = kmReturned;
        //    this.Reneted = rent;
        //    this.Returned = returned;
        //    this.Cost = cost;
        //    this.VechileStatus = vStatus;

        //}
    }
}
