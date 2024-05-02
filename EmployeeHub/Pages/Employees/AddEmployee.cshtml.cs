using EmployeeHub.Data;
using EmployeeHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeHub.Pages.Employees
{
    public class AddEmployeeModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Employee Employee { get; set; }

        public AddEmployeeModel(ApplicationDbContext context)
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
                await _context.Employee.AddAsync(Employee);
                await _context.SaveChangesAsync();

                return RedirectToPage("./ViewEmployee");
            }

            return Page();
        }
    }
}