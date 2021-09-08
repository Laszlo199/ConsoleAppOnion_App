using System.Collections.Generic;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationForTheCustomer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
            
        // GET
        [HttpGet]
        public List<Customer> ReadAll()
        {
            return _customerService.GetAllCustomers();
        }
        
        //
        [HttpPost]  
        public Customer Create(Customer customer)
        {
            if (customer == null)
            {
                return null;
            }

            return _customerService.CreateCustomer(customer);
        }


        [HttpGet("{id}")]
        public Customer ReadById(int id)
        {
            return _customerService.FindCustomerById(id);
        }
        
        [HttpPut("{id}")]
        public Customer Update(int id, Customer customer)
        {
            return _customerService.UpdateCustomer(customer);
        }
        
        [HttpDelete("{id}")]
        public Customer Delete(int id)
        {
            return _customerService.DeleteCustomer(id);
        }
    }
}