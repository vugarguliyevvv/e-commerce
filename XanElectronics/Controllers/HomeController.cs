using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XanElectronics.Dal;
using XanElectronics.ViewModels;

namespace XanElectronics.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Products = _context.Products.Include(x => x.ProductImages).Include(x => x.Category).ToList(),
                Categories = _context.Categories.Include(x=>x.Products).ToList(),
                Brands=_context.Brands.ToList(),
                Services=_context.Services.ToList(),
                Sliders=_context.Sliders.ToList(),
                Banners=_context.Banners.ToList()
            };
            return View(homeVM);
        }
    }
}
