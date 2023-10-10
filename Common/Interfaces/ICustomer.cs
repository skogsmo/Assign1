using Common.Models;

namespace Common.Interfaces
{
    public interface ICustomer
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Ssn { get; set; }

        List<Customer> GetCustomers();
    }
}
