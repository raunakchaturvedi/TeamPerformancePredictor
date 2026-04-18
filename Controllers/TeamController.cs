using Microsoft.AspNetCore.Mvc;
using TPPProject.Data;
using TPPProject.Models;

namespace TPPProject.Controllers
{
    public class TeamsController : Controller
    {
        private readonly AppDbContext _context;

        public TeamsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teams = _context.Teams.ToList();
            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View(team);
            }

            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var team = _context.Teams.Find(id);

            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View(team);
            }

            _context.Teams.Update(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var team = _context.Teams.Find(id);

            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}