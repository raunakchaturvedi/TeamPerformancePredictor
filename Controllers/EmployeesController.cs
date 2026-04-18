using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPPProject.Data;
using TPPProject.Models;

namespace TPPProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees
                                    .Include(e => e.Team)
                                    .ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Teams = _context.Teams.ToList();
            ViewBag.Departments = new List<string>
            {
                "Software Development",
                "DevOps",
                "UI/UX Design",
                "Data Analytics",
                "Cyber Security",
                "Technical Support",
                "Project Management",
                "Cloud Operations"
            };

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teams = _context.Teams.ToList();
                ViewBag.Departments = new List<string>
                {
                    "Software Development",
                    "DevOps",
                    "UI/UX Design",
                    "Data Analytics",
                    "Cyber Security",
                    "Technical Support",
                    "Project Management",
                    "Cloud Operations"
                };

                return View(emp);
            }

            _context.Employees.Add(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.Find(id);

            if (emp == null)
            {
                return NotFound();
            }

            ViewBag.Teams = _context.Teams.ToList();
            ViewBag.Departments = new List<string>
            {
                "Software Development",
                "DevOps",
                "UI/UX Design",
                "Data Analytics",
                "Cyber Security",
                "Technical Support",
                "Project Management",
                "Cloud Operations"
            };

            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teams = _context.Teams.ToList();
                ViewBag.Departments = new List<string>
                {
                    "Software Development",
                    "DevOps",
                    "UI/UX Design",
                    "Data Analytics",
                    "Cyber Security",
                    "Technical Support",
                    "Project Management",
                    "Cloud Operations"
                };

                return View(emp);
            }

            _context.Employees.Update(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);

            if (emp == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}