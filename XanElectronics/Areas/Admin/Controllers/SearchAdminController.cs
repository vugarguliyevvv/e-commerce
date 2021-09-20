using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XanElectronics.Dal;
using XanElectronics.Models;

namespace XanElectronics.Areas.Admin.Controllers
{
    public class SearchAdminController : Controller
    {
        private readonly DataContext _context;
        public SearchAdminController(DataContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            return Ok();
        }
        
        public IActionResult Search(string search)
        {
            IEnumerable<Product> list = new List<Product>();     
            if (search != null)
            {
                list = _context.Products.Include(p => p.ProductImages)
                    .Where(t => t.Name.ToLower().Contains(search.ToLower())).Take(5);
                return PartialView("_partialAdminProduct", list);
            }
            return Ok();   
        }
    }
}