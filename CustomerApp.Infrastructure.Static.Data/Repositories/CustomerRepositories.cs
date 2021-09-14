using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.Static.Data.Repositories
{
    public class CustomerRepositories: ICustomerRepository
    {
        static int id = 1;


        public CustomerRepositories()
        {
            if (FakeDB.Customers.Count >= 1) return;
            var customer1 = new Customer()
            {
                Id = FakeDB.Id++,
                FirstName = "Bob",
                LastName = "Toka",
                Address = "Toka street 222"
            };
                FakeDB.Customers.Add(customer1);

                var customer2 = new Customer()
                {
                    Id = FakeDB.Id++,
                    FirstName = "Andi",
                    LastName = "Hopi",
                    Address = "Skt.KukuPopen 345"
                };
                FakeDB.Customers.Add(customer2);
        }
        public Customer Create(Customer customer)
        {
            customer.Id = FakeDB.Id++;
            FakeDB.Customers.Add(customer);
            return customer;
            
        }

        public Customer ReadById(int id)
        {
            return FakeDB.Customers.Select(c => new Customer()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address
            }).FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> ReadAll()
        {
            return FakeDB.Customers;
        }

        public Customer Delete(int id)
        {
            var customerFound = ReadById(id);
            if (customerFound == null) return null;
            
            FakeDB.Customers.Remove(customerFound);
            return customerFound;
        }

        public Customer Update(Customer customerUpdate)
        {
            var customerFromDB = ReadById(customerUpdate.Id);

            if (customerFromDB == null) return null;
            
                customerFromDB.FirstName = customerUpdate.FirstName;
                customerFromDB.FirstName = customerUpdate.LastName;
                customerFromDB.FirstName = customerUpdate.Address;
                
            return customerFromDB;
        }
    }
}