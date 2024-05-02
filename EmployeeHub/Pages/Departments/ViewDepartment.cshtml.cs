using EmployeeHub.Data;
using EmployeeHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeHub.Pages.Departments
{
    [Authorize]
    public class ViewDepartmentModel : PageModel
    {
        public List<Department> departments = new List<Department>();

        private readonly ApplicationDbContext _context;

        public ViewDepartmentModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            departments = _context.Department.Where( x => !x.IsDeleted).ToList();
        }
    }
}