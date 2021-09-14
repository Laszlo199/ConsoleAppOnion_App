using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface ICustomerRepository
    {
        Customer Create(Customer customer);
        Customer ReadById(int id);
        IEnumerable<Customer> ReadAll();
        Customer Delete(int id);
        Customer Update(Customer customerUpdate);
       
    }
}