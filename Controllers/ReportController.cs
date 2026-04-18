using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPPProject.Data;

namespace TPPProject.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees
                                    .Include(e => e.Team)
                                    .Include(e => e.BurnoutRisks)
                                    .Include(e => e.Performances)
                                    .ToList();

            return View(employees);
        }
    }
}