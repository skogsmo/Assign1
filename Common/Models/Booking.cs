using Common.Enums;

namespace Common.Models
{
    public class Booking
    {
        public Vehicle Car { get; set; }
        public Customer Customer { get; set; }
        public int Kmrented { get; set; }
        public int Kmreturned { get; set; }
        public string Reneted { get; set; }
        public string Returned { get; set; }
        public int Cost { get; set; }
        public VehicleStatus VechileStatus { get; set; }

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

        public List<Booking> GetBookings()
        {
            List<Booking> list = new List<Booking>();
            list.Add(new Booking { Car = null, Customer = null, Kmrented = 1000, Kmreturned = 1000, Reneted = "9/9/2023", Returned = "9/14/2023", Cost = 999, VechileStatus = VehicleStatus.Closed });
            return null;
        }
    }
}
