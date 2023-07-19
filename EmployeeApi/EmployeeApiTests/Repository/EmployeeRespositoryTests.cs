using EmployeeApi.Data;
using EmployeeApi.Models;
using Moq;
using Xunit;

namespace EmployeeApi.Repository.Tests
{
    public class EmployeeRespositoryTests
    {
        Mock<IEmployeeRepository> repositoryMock;
        List<Employee> employeelist;
        public EmployeeRespositoryTests()
        {
            repositoryMock = new Mock<IEmployeeRepository>();
            employeelist = new List<Employee>()
            {
                new Employee() { EmployeeID = 1, FirstName ="ABC", LastName = "XYZ", Adress = "Pune", Age = 23, EmailID = "abc@gmail.com"},
                new Employee() { EmployeeID = 2, FirstName ="Sita", LastName = "Raman", Adress = "Pune", Age = 56, EmailID = "ac@gmail.com"},
            };
        }
        

        [Fact]
        public void DeleteEmployeeTest()
        {
            // Setup
            repositoryMock.Setup(r => r.DeleteEmployee(20)).Returns(Task.FromResult(new Employee()));

            // Execute
            var repositoryObject = new InMemoryEmployeeRepository(employeelist);
            var response = repositoryObject.DeleteEmployee(20);

            //Verify
            Assert.NotNull(response);
    
        }

        [Fact]
        public void GetAllEmployeesTest()
        {
            // Setup
            repositoryMock.Setup(r => r.GetAllEmployees()).Returns(Task.FromResult(new List<Employee>()));

            // Execute
            var repositoryObject = new InMemoryEmployeeRepository(employeelist);
            var response = repositoryObject.GetAllEmployees();

            //Verify
            Assert.Equal(2, response.Result.Count);

        }

        [Fact]
        public void CreateEmployeeTest()
        {
            // Setup
            repositoryMock.Setup(r => r.CreateEmployee(new Employee())).Returns(Task.FromResult(new Employee()));

            // Execute
            var repositoryObject = new InMemoryEmployeeRepository(employeelist);
            var response = repositoryObject.CreateEmployee(new Employee());

            //Verify
            Assert.NotNull(response);
        }
    }
}