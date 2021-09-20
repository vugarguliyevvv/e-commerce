using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XanElectronics.Dal;

namespace XanElectronics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubscriptionController : Controller
    {
        private readonly DataContext _context;

        public SubscriptionController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Subscriptions.ToList());
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var subscription = _context.Subscriptions.FirstOrDefault(x => x.Id == id);
            if (subscription == null) return NotFound();
            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
