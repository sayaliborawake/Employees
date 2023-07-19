using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Repository
{
    public class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;
        public InMemoryEmployeeRepository(List<Employee> employees) 
        {
            _employees= employees;
        }
        public Task<Employee?> CreateEmployee(Employee employee)
        {
            _employees.Add(employee);
            return Task.FromResult(employee);
        }

        public Task<Employee?> DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(x => x.EmployeeID == id);
            if (employee != null)
                _employees.Remove(employee);

            return Task.FromResult(employee);
        }

        public Task<List<Employee>> GetAllEmployees() => Task.FromResult(_employees);

        public Task<Employee?> GetEmployeeById(int id) => Task.FromResult(_employees.FirstOrDefault(x => x.EmployeeID == id));
      

        public Task<Employee?> UpdateEmployee(int id, Employee employee)
        {
            var emp = _employees.FirstOrDefault(x => x.EmployeeID == id);

            if (emp != null)
            {
                // update the domain model object from update request DTO (maop DTO to Domain model)
                emp.LastName = employee.LastName;
                emp.Adress = employee.Adress;
                emp.Age = employee.Age;
                emp.EmailID = employee.EmailID;
                
            }

            return Task.FromResult(emp);
        }
    }
}
