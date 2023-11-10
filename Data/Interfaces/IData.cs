using Common.Enums;
using Common.Interfaces;
using Common.Models;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IData : IVehicle,ICustomer, IBooking
    {
        // G del
        List<IVehicle> GetVehicles();
        List<ICustomer> GetCustomers();
        List<IBooking> GetBookings();

        // VG del

        int NextVehicleId { get; }
        int NextPersonId { get; }
        int NextBookingId { get; }

        List<T> Get<T>(Expression<Func<T, bool>>? expression);
        T? Single<T>(Expression<Func<T, bool>>? expression);
        public void Add<T>(T item);

        void RentVehicle(int vehicleId, int customerId);
        void ReturnVehicle(int vehicleId, int cId, int input);
        public string[] VehicleStatusName => VehicleStatusName; // return enum constant???
        public string[] VehicleTypeName => VehicleTypeName; // return enum constant???




    }
}
