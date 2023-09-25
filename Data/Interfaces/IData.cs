using Common.Interfaces;
using Common.Models;

namespace Data.Interfaces
{
    public interface IData : ICar, ICustomer, IBooking
    {
        List<Vehicle> GetVehicles();
        List<Customer> GetCustomers();
        List<Booking> GetBookings();


    }
}
