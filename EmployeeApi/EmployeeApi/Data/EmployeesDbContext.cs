using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Data
{
    public class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed the data for Employees
            var employeeList = new List<Employee>()
            {
                new Employee ()
                {
                     EmployeeID = 1,
                     FirstName = "Ishaan",
                     LastName = "Batra",
                     Adress = "Delhi",
                     Age = 25,
                     EmailID = "ib@gmail.com"
                },
                new Employee ()
                {
                     EmployeeID = 2,
                     FirstName = "Priyanks",
                     LastName = "Singh",
                     Adress = "Banglore",
                     Age = 32,
                     EmailID = "ps@gmail.com"
                },
                 new Employee ()
                {
                     EmployeeID = 3,
                     FirstName = "Shweta",
                     LastName = "Agarwal",
                     Adress = "Pune",
                     Age = 40,
                     EmailID = "ps@gmail.com"
                },
                new Employee ()
                {
                     EmployeeID = 4,
                     FirstName = "Deepa",
                     LastName = "Patel",
                     Adress = "Pune",
                     Age = 38,
                     EmailID = "dp@gmail.com"
                }
            };

            // Seed employee data
            modelBuilder.Entity<Employee>().HasData(employeeList);
            
        }
    }
}
