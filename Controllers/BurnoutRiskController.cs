using Microsoft.AspNetCore.Mvc;
using TPPProject.Data;
using TPPProject.Models;
using Microsoft.EntityFrameworkCore;

namespace TPPProject.Controllers
{
    public class BurnoutRiskController : Controller
    {
        private readonly AppDbContext _context;

        public BurnoutRiskController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var records = _context.BurnoutRisks
                                  .Where(b => b.EmployeeId != null)
                                  .Include(b => b.Employee)
                                  .ToList();

            return View(records);
        }

        public IActionResult Create()
        {
            ViewBag.Employees = _context.Employees.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(BurnoutRisk risk)
        {
            int score = risk.WorkingHours + risk.OvertimeHours + risk.StressLevel - risk.LeaveCount;

            if (score >= 70)
                risk.RiskLevel = "High";
            else if (score >= 40)
                risk.RiskLevel = "Medium";
            else
                risk.RiskLevel = "Low";

            _context.BurnoutRisks.Add(risk);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    
    }
}
