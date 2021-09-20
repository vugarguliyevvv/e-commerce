using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XanElectronics.Dal;

namespace XanElectronics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MessageController : Controller
    {
        private readonly DataContext _context;

        public MessageController(DataContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            return View(_context.Messages.ToList());
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var message = _context.Messages.FirstOrDefault(x => x.Id == id);
            if (message == null) return NotFound();
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}