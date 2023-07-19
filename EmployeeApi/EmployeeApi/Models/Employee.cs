using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string EmailID { get; set; }
        public int Age { get; set; }
    }
}
