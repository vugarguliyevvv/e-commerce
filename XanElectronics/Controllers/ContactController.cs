using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XanElectronics.Dal;
using XanElectronics.Models;
using XanElectronics.ViewModels;

namespace XanElectronics.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataContext _context;
        public ContactController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ContactVM contactVM = new ContactVM
            {
                Bio = _context.Bios.FirstOrDefault()
            };

            return View(contactVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(MessageCreateVM messageCreateVM)
        {
            ContactVM contactVM = new ContactVM { Bio = _context.Bios.FirstOrDefault() };

            if (!ModelState.IsValid) return View(contactVM);

            Message message = new Message
            {
                Name = messageCreateVM.Name,
                Email = messageCreateVM.Email,
                Subject = messageCreateVM.Subject,
                Context = messageCreateVM.Context
            };
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Subscribe([FromForm] string email)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            bool existSubscription = _context.Subscriptions.Any(e => e.Email == email);
            if (existSubscription)
            {
                return Ok(existSubscription);
            }

            Subscription subscription = new Subscription { Email = email };
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();

            return Ok(existSubscription);
        }
    }
}
