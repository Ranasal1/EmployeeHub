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
                Department.Name = department.Name;
                Department.Description = department.Description;
                Department.ContactInformation = department.ContactInformation;
                Department.Address = department.Address;
                _context.SaveChanges();
                return RedirectToPage("./ViewDepartment");
            }
            return Page();
        }
    }
}
