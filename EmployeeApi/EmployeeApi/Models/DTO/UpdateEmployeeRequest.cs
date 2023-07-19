namespace EmployeeApi.Models.DTO
{
    // We are not allowing to update the First name
    public class UpdateEmployeeRequest
    {
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string EmailID { get; set; }
        public int Age { get; set; }
    }
}
