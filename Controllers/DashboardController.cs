using Microsoft.AspNetCore.Mvc;
using TPPProject.Data;

namespace TPPProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalEmployees = _context.Employees.Count();
            ViewBag.HighBurnout = _context.BurnoutRisks.Count(b => b.RiskLevel == "High");
            ViewBag.MediumBurnout = _context.BurnoutRisks.Count(b => b.RiskLevel == "Medium");
            ViewBag.LowBurnout = _context.BurnoutRisks.Count(b => b.RiskLevel == "Low");

            ViewBag.HighPerformance = _context.Performances.Count(p => p.PerformanceLevel == "High");
            ViewBag.MediumPerformance = _context.Performances.Count(p => p.PerformanceLevel == "Medium");
            ViewBag.LowPerformance = _context.Performances.Count(p => p.PerformanceLevel == "Low");

            return View();
        }
    }
}
