using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly AppDbContext _context;

        public CampaignsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var campaigns = _context.EmailCampaigns.Include(c => c.Group).ToList();
            return View(campaigns);
        }

        public IActionResult Create()
        {
            ViewBag.Groups = new SelectList(_context.Groups, "Id", "Name");
            return View();
        }

        public IActionResult Details(int id)
        {
            var campaign = _context.EmailCampaigns
                .Include(c => c.Group)
                .ThenInclude(g => g.ContactGroups)
                .ThenInclude(cg => cg.Contact)
                .FirstOrDefault(c => c.Id == id);

            if (campaign == null) return NotFound();
            
            return View(campaign);
        }

        [HttpPost]
        public IActionResult Create(EmailCampaign campaign)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Groups = new SelectList(_context.Groups, "Id", "Name");
                return View(campaign);
            }

            campaign.Group = _context.Groups.First(g => g.Id == campaign.GroupId);
            _context.EmailCampaigns.Add(campaign);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var campaign = _context.EmailCampaigns.FirstOrDefault(c => c.Id == id);
            if (campaign == null)
                return NotFound();

            ViewBag.Groups = new SelectList(_context.Groups, "Id", "Name", campaign.GroupId);
            return View(campaign);
        }

        [HttpPost]
        public IActionResult Edit(EmailCampaign campaign)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Groups = new SelectList(_context.Groups, "Id", "Name", campaign.GroupId);
                return View(campaign);
            }

            _context.EmailCampaigns.Update(campaign);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Send(int id)
        {
            var campaign = _context.EmailCampaigns
                .Include(c => c.Group)
                .ThenInclude(g => g.ContactGroups)
                .ThenInclude(cg => cg.Contact)
                .FirstOrDefault(c => c.Id == id);

            if (campaign == null)
                return NotFound();

            var recipients = campaign.Group.ContactGroups
                .Select(cg => cg.Contact.Email)
                .ToList();

            Console.WriteLine($"Wysyłanie kampanii do: {string.Join(", ", recipients)}");

            TempData["Message"] = $"Kampania została wysłana do {recipients.Count} odbiorców.";
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var campaign = _context.EmailCampaigns.Find(id);
            if (campaign != null)
            {
                _context.EmailCampaigns.Remove(campaign);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
