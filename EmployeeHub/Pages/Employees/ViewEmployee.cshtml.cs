using EmployeeHub.Data;
using EmployeeHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeHub.Pages.Employees
{
    public class ViewEmployeeModel : PageModel
    {
        public List<Employee> employees = new List<Employee>();

        private readonly ApplicationDbContext _context;

        public ViewEmployeeModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            employees = _context.Employee.Where(x => !x.IsDeleted).ToList();
        }
    }
}