using System.Linq;
using TPPProject.Models;

namespace TPPProject.Data
{
    public static class DefaultData
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var teams = new Team[]
            {
                new Team
                {
                    TeamName = "Alpha",
                    ProjectName = "HR Portal",
                    TeamLead = "Amit Sharma"
                },
                new Team
                {
                    TeamName = "Beta",
                    ProjectName = "Sales Dashboard",
                    TeamLead = "Neha Verma"
                },
                new Team
                {
                    TeamName = "Gamma",
                    ProjectName = "Inventory System",
                    TeamLead = "Rohit Singh"
                }
            };

            context.Teams.AddRange(teams);
            context.SaveChanges();

            var alpha = context.Teams.First(t => t.TeamName == "Alpha");
            var beta = context.Teams.First(t => t.TeamName == "Beta");
            var gamma = context.Teams.First(t => t.TeamName == "Gamma");

            var employees = new Employee[]
            {
                new Employee
                {
                    Name = "Raunak Chaturvedi",
                    Department = "Software Development",
                    TeamId = alpha.TeamId
                },
                new Employee
                {
                    Name = "Anjali Mehta",
                    Department = "Quality Assurance",
                    TeamId = alpha.TeamId
                },
                new Employee
                {
                    Name = "Karan Patel",
                    Department = "DevOps",
                    TeamId = beta.TeamId
                },
                new Employee
                {
                    Name = "Sneha Gupta",
                    Department = "Data Analytics",
                    TeamId = beta.TeamId
                },
                new Employee
                {
                    Name = "Vikas Nair",
                    Department = "Cyber Security",
                    TeamId = gamma.TeamId
                }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();

            var allEmployees = context.Employees.ToList();

            var burnoutRisks = new BurnoutRisk[]
            {
                new BurnoutRisk
                {
                    EmployeeId = allEmployees[0].EmployeeId,
                    WorkingHours = 9,
                    OvertimeHours = 3,
                    StressLevel = 8,
                    LeaveCount = 1,
                    RiskLevel = "Medium"
                },
                new BurnoutRisk
                {
                    EmployeeId = allEmployees[1].EmployeeId,
                    WorkingHours = 8,
                    OvertimeHours = 1,
                    StressLevel = 4,
                    LeaveCount = 2,
                    RiskLevel = "Low"
                },
                new BurnoutRisk
                {
                    EmployeeId = allEmployees[2].EmployeeId,
                    WorkingHours = 10,
                    OvertimeHours = 4,
                    StressLevel = 9,
                    LeaveCount = 0,
                    RiskLevel = "High"
                },
                new BurnoutRisk
                {
                    EmployeeId = allEmployees[3].EmployeeId,
                    WorkingHours = 8,
                    OvertimeHours = 2,
                    StressLevel = 6,
                    LeaveCount = 1,
                    RiskLevel = "Medium"
                },
                new BurnoutRisk
                {
                    EmployeeId = allEmployees[4].EmployeeId,
                    WorkingHours = 7,
                    OvertimeHours = 1,
                    StressLevel = 3,
                    LeaveCount = 3,
                    RiskLevel = "Low"
                }
            };

            context.BurnoutRisks.AddRange(burnoutRisks);
            context.SaveChanges();

            var performances = new Performance[]
            {
                new Performance
                {
                    EmployeeId = allEmployees[0].EmployeeId,
                    TasksCompleted = 70,
                    DeadlinesMet = 65,
                    ProductivityScore = 60,
                    TeamworkScore = 58,
                    PerformanceLevel = "High"
                },
                new Performance
                {
                    EmployeeId = allEmployees[1].EmployeeId,
                    TasksCompleted = 45,
                    DeadlinesMet = 40,
                    ProductivityScore = 42,
                    TeamworkScore = 39,
                    PerformanceLevel = "Medium"
                },
                new Performance
                {
                    EmployeeId = allEmployees[2].EmployeeId,
                    TasksCompleted = 80,
                    DeadlinesMet = 75,
                    ProductivityScore = 70,
                    TeamworkScore = 68,
                    PerformanceLevel = "High"
                },
                new Performance
                {
                    EmployeeId = allEmployees[3].EmployeeId,
                    TasksCompleted = 35,
                    DeadlinesMet = 30,
                    ProductivityScore = 32,
                    TeamworkScore = 28,
                    PerformanceLevel = "Low"
                },
                new Performance
                {
                    EmployeeId = allEmployees[4].EmployeeId,
                    TasksCompleted = 55,
                    DeadlinesMet = 50,
                    ProductivityScore = 52,
                    TeamworkScore = 48,
                    PerformanceLevel = "Medium"
                }
            };

            context.Performances.AddRange(performances);
            context.SaveChanges();
        }
    }
}