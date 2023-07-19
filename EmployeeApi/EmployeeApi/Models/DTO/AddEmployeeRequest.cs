namespace EmployeeApi.Models.DTO
{
    public class AddEmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string EmailID { get; set; }
        public int Age { get; set; }
    }
}
