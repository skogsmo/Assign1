using Common.Interfaces;

namespace Common.Models
{
    public class Customer : ICustomer
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Ssn { get; set; }

        //public Customer(string fName, string lName, string ssn)
        //{
        //    this.Fname = fName;
        //    this.Lname = lName;
        //    this.Ssn = ssn;
        //}

        public List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();
            return list;
        }
    }
}
