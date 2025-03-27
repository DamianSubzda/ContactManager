using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    public class GroupsController : Controller
    {
        private readonly AppDbContext _context;

        public GroupsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var groups = _context.Groups.ToList();
            return View(groups);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Group group)
        {
            if (!ModelState.IsValid)
                return View(group);

            _context.Groups.Add(group);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var group = _context.Groups.Find(id);
            if (group == null) return NotFound();

            return View(group);
        }

        [HttpPost]
        public IActionResult Edit(Group group)
        {
            if (!ModelState.IsValid)
                return View(group);

            _context.Groups.Update(group);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var group = _context.Groups.Find(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
