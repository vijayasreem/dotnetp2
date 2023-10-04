
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;
using dotnetp2.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnetp2.API
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync(CustomerModel customer)
        {
            var customerId = await _customerService.CreateAsync(customer);
            return Ok(customerId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetByIdAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerModel>>> GetAllAsync()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CustomerModel customer)
        {
            var success = await _customerService.UpdateAsync(customer);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var success = await _customerService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
