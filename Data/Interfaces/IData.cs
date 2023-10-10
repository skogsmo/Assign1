using Common.Interfaces;
using Common.Models;

namespace Data.Interfaces
{
    public interface IData : IVehicle, ICustomer, IBooking
    {
        List<Vehicle> GetVehicles();
        List<Customer> GetCustomers();
        List<Booking> GetBookings();
    }
}
