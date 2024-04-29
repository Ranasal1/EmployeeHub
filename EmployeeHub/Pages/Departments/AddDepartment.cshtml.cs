using EmployeeHub.Data;
using EmployeeHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeHub.Pages.Departments
{
    public class AddDepartmentModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Department Department { get; set; }

        public AddDepartmentModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
             if (ModelState.IsValid)
            {
                await _context.Department.AddAsync(Department);
                await _context.SaveChangesAsync();

                return RedirectToPage("./ViewDepartment");
            }

            return Page();
        }
    }
}