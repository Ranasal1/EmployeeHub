using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeHub.Models
{
    public class DepartmentAudit
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("department")]
        public int DepartmentId { get; set; }
        public virtual Department department { get; set; }
        public string CreatorName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifierName { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}