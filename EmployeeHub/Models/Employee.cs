using System.ComponentModel.DataAnnotations;

namespace EmployeeHub.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "* Name is required")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "* Email is required")]
        public required string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string CreatorName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifierName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        // Foreign key for Department
        public int DepartmentId { get; set; }

        // Navigation property to represent the Department of the Employee
        public Department Department { get; set; }
    }
}
