using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPPProject.Data;
using TPPProject.Models;

namespace TPPProject.Controllers
{
    public class TeamPerformanceController : Controller
    {
        private readonly AppDbContext _context;

        public TeamPerformanceController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teams = _context.Teams
                .Include(t => t.Employees)
                .ToList();

            var burnoutRisks = _context.BurnoutRisks.ToList();
            var performances = _context.Performances.ToList();

            var results = new List<Result>();

            foreach (var team in teams)
            {
                var employeeIds = team.Employees?.Select(e => e.EmployeeId).ToList() ?? new List<int>();

                var teamBurnouts = burnoutRisks
                    .Where(b => b.EmployeeId.HasValue && employeeIds.Contains(b.EmployeeId.Value))
                    .ToList();

                var teamPerformances = performances
                    .Where(p => p.EmployeeId.HasValue && employeeIds.Contains(p.EmployeeId.Value))
                    .ToList();

                int highBurnout = teamBurnouts.Count(b => b.RiskLevel == "High");
                int mediumBurnout = teamBurnouts.Count(b => b.RiskLevel == "Medium");
                int lowBurnout = teamBurnouts.Count(b => b.RiskLevel == "Low");

                int highPerformance = teamPerformances.Count(p => p.PerformanceLevel == "High");
                int mediumPerformance = teamPerformances.Count(p => p.PerformanceLevel == "Medium");
                int lowPerformance = teamPerformances.Count(p => p.PerformanceLevel == "Low");

                int teamScore =
                    (highPerformance * 2)
                    + (mediumPerformance * 1)
                    - (highBurnout * 2)
                    - (mediumBurnout * 1);

                string teamLevel;

                if (teamScore >= 2)
                    teamLevel = "High";
                else if (teamScore >= 0)
                    teamLevel = "Medium";
                else
                    teamLevel = "Low";

                results.Add(new Result
                {
                    TeamId = team.TeamId,
                    TeamName = team.TeamName,
                    ProjectName = team.ProjectName,
                    TeamLead = team.TeamLead,
                    TotalEmployees = employeeIds.Count,

                    HighBurnoutCount = highBurnout,
                    MediumBurnoutCount = mediumBurnout,
                    LowBurnoutCount = lowBurnout,

                    HighPerformanceCount = highPerformance,
                    MediumPerformanceCount = mediumPerformance,
                    LowPerformanceCount = lowPerformance,

                    TeamScore = teamScore,
                    TeamPerformanceLevel = teamLevel
                });
            }

            return View(results);
        }
    }
}