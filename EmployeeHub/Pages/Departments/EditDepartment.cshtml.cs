using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeHub.Data;
using EmployeeHub.Models;
using System;

namespace EmployeeHub.Pages.Departments
{
    public class EditDepartmentModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditDepartmentModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Department Department { get; set; }
        public IActionResult OnGet(int id)
        {
            Department = _context.Department.Find(id);
            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }
         public IActionResult OnPost(Department department)
        {
            Department = _context.Department.FirstOrDefault(x => x.Id == department.Id);
            if (ModelState.IsValid && Department != null)
            {
                // Capture original department details
                var originalDepartment = new Department
                {
                    Name = Department.Name,
                    Description = Department.Description,
                    ContactInformation = Department.ContactInformation,
                    Address = Department.Address
                };

                Department.Name = department.Name;
                Department.Description = department.Description;
                Department.ContactInformation = department.ContactInformation;
                Department.Address = department.Address;

                _context.SaveChanges();

                // Check if department details have changed
                if (!Department.Equals(originalDepartment))
                {
                    var existingAuditRecord = _context.DepartmentAudit.FirstOrDefault(a => a.DepartmentId == Department.Id);

                    if (existingAuditRecord != null)
                    {
                        existingAuditRecord.ModifiedDate = DateTime.Now;
                        existingAuditRecord.ModifierName = User.Identity.Name;

                        _context.SaveChanges();
                    }
                }
                else
                {
                    Console.WriteLine("No changes in department details.");
                }

                return RedirectToPage("./ViewDepartment");
            }
            return Page();
        }
    }
}
