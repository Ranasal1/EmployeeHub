using System.ComponentModel.DataAnnotations;

namespace EmployeeHub.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* Name is required")]
        public string Name { get; set; }
        [StringLength(30)]
        public string Description { get; set; }
        public string ContactInformation { get; set; }
        public string Address { get; set; }

    }
}
