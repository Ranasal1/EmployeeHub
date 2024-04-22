using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeHub.Data;
using EmployeeHub.Models;

namespace EmployeeHub.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeHub.Data.ApplicationDbContext _context;

        public IndexModel(EmployeeHub.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Department = await _context.Department.ToListAsync();
        }
    }
}
