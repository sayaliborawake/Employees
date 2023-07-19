using EmployeeApi.Models;
using EmployeeApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Repository
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllEmployees();
        public Task<Employee?> GetEmployeeById(int id);
        public Task<Employee?> CreateEmployee(Employee employee);

        public Task<Employee?> UpdateEmployee(int id, Employee employee);

        public Task<Employee?> DeleteEmployee(int id);

    }
}
