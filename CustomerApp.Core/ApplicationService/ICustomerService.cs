using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService
{
    public interface ICustomerService
    {
        
        Customer UpdateCustomer(Customer customerUpdated);
        Customer FindCustomerById(int id);
        List<Customer> GetAllCustomers();
        Customer DeleteCustomer(int id);
        Customer NewCustomer(string firstName, string lastName, string address);
        Customer CreateCustomer(Customer cust);
        List<Customer> GetAllCustomerByFirstName(string name);
        Customer FindCustomerByIdIncludeOrders(int id);
        
    }
}