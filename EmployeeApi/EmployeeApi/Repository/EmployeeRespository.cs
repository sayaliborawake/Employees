using EmployeeApi.Data;
using EmployeeApi.Models;
using EmployeeApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Repository
{
    public class EmployeeRespository : IEmployeeRepository
    {
        private readonly EmployeesDbContext _dbContext;

        public EmployeeRespository(EmployeesDbContext dbContext) => this._dbContext = dbContext;

        public async Task<Employee?> CreateEmployee(Employee employee)
        {
            // Add newly created employee to database
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> DeleteEmployee(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
            return employee;
        }


        public async Task<List<Employee>> GetAllEmployees() => await _dbContext.Employees.ToListAsync();

        public async Task<Employee?> GetEmployeeById(int id) => await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);

        public async Task<Employee?> UpdateEmployee(int id, Employee employee)
        {
            var emp = await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);

            if (emp != null)
            {
                // update the domain model object from update request DTO (maop DTO to Domain model)
                emp.LastName = employee.LastName;
                emp.Adress = employee.Adress;
                emp.Age = employee.Age;
                emp.EmailID = employee.EmailID;
                await _dbContext.SaveChangesAsync();
            }

            return emp;
        }
    }
}
