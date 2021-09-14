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
        public ActionResult<Customer> ReadById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be Bigger then 0");
            }

            return _customerService.FindCustomerByIdIncludeOrders(id);
        }
        
        [HttpPut("{id}")]
        public ActionResult<Customer> Update(int id,[FromBody]Customer customer)
        {
            if (id<1 || id != customer.Id)
            {
                BadRequest("bazmeg a kurwa anyad LOL");
            }

            
            return Ok(_customerService.UpdateCustomer(customer));
        }
        
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            var customer =_customerService.DeleteCustomer(id);
            if (customer == null) return StatusCode(404, "Not found"+id);
            {
                
            }
            return Ok(customer.Id + ("Deleted"));
        }
    }
}