namespace EmployeeHub.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
    }
}
