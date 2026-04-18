using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPPProject.Data;
using TPPProject.Models;

namespace TPPProject.Controllers
{
    public class PerformanceController : Controller
    {
        private readonly AppDbContext _context;

        public PerformanceController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var records = _context.Performances
                                  .Where(p => p.EmployeeId != null)
                                  .Include(p => p.Employee)
                                  .ToList();

            return View(records);
        }

        public IActionResult Create()
        {
            ViewBag.Employees = _context.Employees.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Performance performance)
        {
            int score = performance.TasksCompleted
                      + performance.DeadlinesMet
                      + performance.ProductivityScore
                      + performance.TeamworkScore;

            if (score >= 250)
                performance.PerformanceLevel = "High";
            else if (score >= 150)
                performance.PerformanceLevel = "Medium";
            else
                performance.PerformanceLevel = "Low";

            _context.Performances.Add(performance);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}