using EmployeeApi.Data;
using EmployeeApi.Models;
using EmployeeApi.Models.DTO;
using EmployeeApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesDbContext _dbContext;

        public IEmployeeRepository _employeeRepository { get; }

        public EmployeesController(EmployeesDbContext employeesDbContext, IEmployeeRepository employeeRepository)
        {
            this._dbContext = employeesDbContext;
            this._employeeRepository = employeeRepository;
        }

        // GET all Employees
        // GET: https://localhost:portnumber/api/employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees() => Ok(await _employeeRepository.GetAllEmployees());

        // Get employee by ID
        // GET: https://localhost:portnumber/api/employees/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute]int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            return employee == null ? NotFound() : Ok(employee);
        }

        // POST to create new employee
        // POST: https://localhost:portnumber/api/employees
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] AddEmployeeRequest addEmployeeRequestDto)
        {
            // Map DTO to domain model
            var employeeDomainModel = new Employee()
            {
                Adress = addEmployeeRequestDto.Adress,
                Age= addEmployeeRequestDto.Age,
                EmailID= addEmployeeRequestDto.EmailID,
                FirstName= addEmployeeRequestDto.FirstName,
                LastName= addEmployeeRequestDto.LastName
            };

            // Add newly created employee to database
            var employee = await _employeeRepository.CreateEmployee(employeeDomainModel);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeDomainModel.EmployeeID }, employeeDomainModel);
        }

        // Update employee
        // PUT: https://localhost:portnumber/api/employees/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute]int id, [FromBody]UpdateEmployeeRequest updateEmployeeRequest)
        {
            // Map DTO to domain model
            var emaployeeDomainModel = new Employee()
            {
                Adress= updateEmployeeRequest.Adress,
                Age= updateEmployeeRequest.Age,
                EmailID= updateEmployeeRequest.EmailID,
                LastName = updateEmployeeRequest.LastName
            };

            var employee = await _employeeRepository.UpdateEmployee(id, emaployeeDomainModel);

            return employee !=null ? Ok(employee) : NotFound();
        }

        // Delete employee
        // DELETE: https://localhost:portnumber/api/employees/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute]int id) => await _employeeRepository.DeleteEmployee(id) != null ? Ok() : NotFound();
    }
}