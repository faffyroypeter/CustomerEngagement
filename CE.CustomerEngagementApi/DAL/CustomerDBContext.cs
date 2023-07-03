using CE.CustomerEngagementApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CE.CustomerEngagementApi.DAL
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions options) : base(options)
        {
        }

        // Acts as tables for 

        public DbSet<Customer> Customers { get; set; }


    }
}
