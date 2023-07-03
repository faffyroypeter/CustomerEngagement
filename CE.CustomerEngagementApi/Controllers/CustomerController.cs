using CE.CustomerEngagementApi.DAL;
using CE.CustomerEngagementApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CE.CustomerEngagementApi.Controllers
{
    [ApiController] // to denote this is a controller
    [Route("api/[controller]")] // to denoate the route should refer to the controller
    public class CustomerController : Controller
    {
        private readonly CustomerDBContext customerDBContext;

        // Inject db Context
        public CustomerController(CustomerDBContext customerDBContext)
        {
            this.customerDBContext = customerDBContext;
        }

        [HttpGet] // swagger to use the UI, open API documentation this annotation is a must
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await customerDBContext.Customers.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid id)
        {
            // Find the value by the id of the customer.
            var customerSearch = await customerDBContext.Customers.FirstOrDefaultAsync(x => x.CustomerId.Equals(id));

            if (customerSearch != null)
            {
                return Ok(customerSearch);
            }

            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerRequest addCustomerRequest)
        {
            // when customer request is not null
            if (addCustomerRequest != null)
            {
                // assign the incomign request to Domain Model
                Customer customer = new Customer()
                {
                    CustomerId = Guid.NewGuid(),
                    FirstName = addCustomerRequest?.FirstName,
                    LastName = addCustomerRequest?.LastName
                };

                // Add entity - adds the new records
                await customerDBContext.AddAsync(customer);
                // saves the result to the database
                await customerDBContext.SaveChangesAsync();

                return Ok(customer);
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id:guid}")] // Type safe id parameter from route
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, UpdateCustomerRequest updateCustomerRequest)
        {
            if (updateCustomerRequest != null)
            {
                // Find the value by the id of the customer.
                var customerSearch = customerDBContext.Customers.FirstOrDefault(x => x.CustomerId.Equals(id));

                if (customerSearch != null)
                {
                    // Update the values with the incoming request
                    customerSearch.FirstName = updateCustomerRequest.FirstName;
                    customerSearch.LastName = updateCustomerRequest.LastName;

                    // assign the incomign request to Domain Model
                    customerDBContext.Update(customerSearch);
                    // saves the result to the database
                    await customerDBContext.SaveChangesAsync();
                }

                return Ok(customerSearch);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:guid}")] // Type safe id parameter from route
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
        {
            // Find the value by the id of the customer.
            var customerSearch = customerDBContext.Customers.FirstOrDefault(x => x.CustomerId.Equals(id));

            if (customerSearch != null)
            {
                // Remove from the storage
                customerDBContext.Remove(customerSearch);
                // saves the result to the database
                await customerDBContext.SaveChangesAsync();
            }

            return Ok(customerSearch);

        }
    }
}
