using Common.Interfaces;
using Common.Models;

namespace Data.Interfaces
{
    public interface IData : IVehicle, ICustomer, IBooking
    {
        List<IVehicle> GetVehicles();
        List<Customer> GetCustomers();
        List<Booking> GetBookings();
    }
}
