using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerRepository _customerRepo;
        private readonly IOrderRepository _orderRepo;

        public CustomerService(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepo = customerRepository;
            _orderRepo = orderRepository;
        }
        
        public Customer UpdateCustomer(Customer customerUpdated)
        {
            var customer = FindCustomerById(customerUpdated.Id);
            customer.FirstName = customerUpdated.FirstName;
            customer.LastName = customerUpdated.LastName;
            customer.Address = customerUpdated.Address;
            return customer;
        }

        public Customer FindCustomerById(int id)
        {
            return _customerRepo.ReadById(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepo.ReadAll().ToList();
        }

        public List<Customer> GetAllCustomerByFirstName(string name)
        {
            var list = _customerRepo.ReadAll();
            var queryContinued =list.Where(cust => cust.FirstName.Equals(name));
            queryContinued.OrderBy(customer => customer.FirstName);
            return queryContinued.ToList();
        }

        public Customer FindCustomerByIdIncludeOrders(int id)
        {
            var customer = _customerRepo.ReadById(id);
            customer.Orders = _orderRepo.ReadAll().Where(order => order.Customer.Id == customer.Id).ToList(); 
            return customer;
        }

        public Customer DeleteCustomer(int id)
        {
            return _customerRepo.Delete(id);
        }

        public Customer NewCustomer(string firstName, string lastName, string address)
        {
            var cust = new Customer()
            { 
                FirstName = firstName,
                LastName = lastName,
                Address = address,
            };
            return cust;
        }

        public Customer CreateCustomer(Customer cust)
        {
            return _customerRepo.Create(cust);
        }
    }
}