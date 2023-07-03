using CE.WebApiSample.Model;
using Microsoft.EntityFrameworkCore;

namespace CE.WebApiSample.DataAccessLayer
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }  

    }
}
