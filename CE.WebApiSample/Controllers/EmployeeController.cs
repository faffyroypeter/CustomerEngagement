using CE.WebApiSample.DataAccessLayer;
using CE.WebApiSample.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.Reflection.Metadata.Ecma335;

namespace CE.WebApiSample.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDBContext employeeDBContext1;

        public EmployeeController(EmployeeDBContext employeeDBContext1)
        {
            this.employeeDBContext1 = employeeDBContext1;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            // Non Blocking call to make the application efficiently operating
            return Ok(await employeeDBContext1.Employees.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee(InsertEmployeeRequest insertEmployeeRequest)
        {

            if (insertEmployeeRequest != null)
            {
                Employee employee = new Employee();

                employee.EmployeeId = new Guid();
                employee.FirstName = insertEmployeeRequest.FirstName;
                employee.LastName = insertEmployeeRequest.LastName;


                await employeeDBContext1.Employees.AddAsync(employee);
                await employeeDBContext1.SaveChangesAsync();

                return Ok(employee);
            }
            else
            {
                return BadRequest("Employee is not available");
            }
        }

        [HttpPut]
        [Route("{id:guid}")] // Curly braces - Possible omission.
        public async Task<IActionResult> InsertEmployee([FromRoute] Guid id, UpdateEmployeeRequest insertEmployeeRequest)
        {
            //Tuple<string, string, string, string, string> studentRecords = new Tuple<string, string, string, string, string>(
            //    "B01", "Peter", "Raj", "343", "2343");

            if (insertEmployeeRequest != null)
            {
                // Collection Syntax to search an element from the list of items
                var employeeResult = await employeeDBContext1.Employees.FirstOrDefaultAsync(x => x.EmployeeId.Equals(id));

                if (employeeResult != null)
                {
                    employeeResult.FirstName = insertEmployeeRequest.FirstName.;
                    employeeResult.LastName = insertEmployeeRequest.LastName;

                    employeeDBContext1.Employees.Update(employeeResult);

                    await employeeDBContext1.SaveChangesAsync();
                }

                return Ok(employeeResult);
            }
            else
            {
                return BadRequest("Employee is not available");
            }
        }

        [HttpDelete]
        [Route("{id:guid}")] // Curly braces - Possible omission.
        public async Task<IActionResult> InsertEmployee([FromRoute] Guid id)
        {
            // LINQ Syntax to search an element from the list of items
            var employeeResult = employeeDBContext1.Employees.FirstOrDefault(x => x.EmployeeId.Equals(id));

            if (employeeResult != null)
            {
                employeeDBContext1.Employees.Remove(employeeResult);
                await employeeDBContext1.SaveChangesAsync();
            }

            return Ok(employeeResult);
        }
    }
}
