using EmployeeHub.Data;
using EmployeeHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeHub.Pages.Departments
{
    public class DeleteDepartmentModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteDepartmentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Department = _context.Department.Find(id);
            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync(Department department)
        {
            Department = _context.Department.FirstOrDefault(x => x.Id == department.Id);
            if (Department != null)
            {
                Department.IsDeleted = true;
                _context.SaveChanges();
                return RedirectToPage("./ViewDepartment");
            }
            return Page();
        }

    } 

}