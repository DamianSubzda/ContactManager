using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Controllers
{
    public class ContactsController : Controller
    {
        private readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contacts = _context.Contacts.ToList();
            return View(contacts);
        }

        public IActionResult Create()
        {
            ViewBag.Groups = _context.Groups.ToList();
            return View();
        }

        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts
                .Include(c => c.ContactGroups)
                .FirstOrDefault(c => c.Id == id);

            if (contact == null)
                return NotFound();

            ViewBag.Groups = _context.Groups.ToList();
            ViewBag.SelectedGroupIds = contact.ContactGroups.Select(cg => cg.GroupId).ToList();

            return View(contact);
        }

        [HttpPost]
        public IActionResult Create(Contact contact, List<int> groupIds)
        {
            if (ModelState.IsValid)
            {
                contact.ContactGroups = groupIds
                    .Select(gid => new ContactGroup { GroupId = gid, Contact = contact })
                    .ToList();

                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Groups = _context.Groups.ToList();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact, List<int> groupIds)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Groups = _context.Groups.ToList();
                ViewBag.SelectedGroupIds = groupIds;
                return View(contact);
            }

            var existing = _context.Contacts
                .Include(c => c.ContactGroups)
                .FirstOrDefault(c => c.Id == contact.Id);

            if (existing == null)
                return NotFound();

            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.Email = contact.Email;

            _context.ContactGroups.RemoveRange(existing.ContactGroups);

            existing.ContactGroups = groupIds
                .Select(gid => new ContactGroup { ContactId = contact.Id, GroupId = gid })
                .ToList();

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
