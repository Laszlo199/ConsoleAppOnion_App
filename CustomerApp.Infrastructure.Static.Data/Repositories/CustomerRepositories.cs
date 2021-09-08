using System.Collections.Generic;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.Static.Data.Repositories
{
    public class CustomerRepositories: ICustomerRepository
    {
        static int id = 1;
        private static List<Customer> _customers = new List<Customer>();
        
        public Customer Create(Customer customer)
        {
            customer.Id = id++;
            _customers.Add(customer);
            return customer;
            
        }x½

        public Customer ReadById(int id)
        {
            foreach (var customer in _customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }

            return null;
        }

        public IEnumerable<Customer> ReadAll()
        {
            return _customers;
        }

        public Customer Delete(int id)
        {
            var customerFound = this.ReadById(id);
            if (customerFound != null)
            {
                _customers.Remove(customerFound);
                return customerFound;
            }

            return null;
        }

        public Customer Update(Customer customerUpdate)
        {
            var customerFromDB = this.ReadById(customerUpdate.Id);

            if (customerFromDB != null)
            {
                customerFromDB.FirstName = customerUpdate.FirstName;
                customerFromDB.FirstName = customerUpdate.LastName;
                customerFromDB.FirstName = customerUpdate.Address;
            }

            return null;
        }
    }
}