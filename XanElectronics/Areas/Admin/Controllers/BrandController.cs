using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using XanElectronics.Dal;
using XanElectronics.Extentions;
using XanElectronics.Helpers;
using XanElectronics.Models;
using XanElectronics.ViewModels;

namespace XanElectronics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public BrandController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET
        public IActionResult Index()
        {
            return View(_context.Brands.Where(x=>x.IsDeleted==false).ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandCreateVM brandCreateVM)
        {
            if (!ModelState.IsValid) return View();

            if (ModelState["Image"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!brandCreateVM.Image.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }

            if (brandCreateVM.Image.MaxLength(200))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                return View();
            }


            string path = Path.Combine("assets", "img", "brand");
            string fileName = await brandCreateVM.Image.SaveImg(_env.WebRootPath, path);

            bool existName = _context.Brands.Any(c => c.Name.ToLower().Trim() == brandCreateVM.Name.ToLower().Trim());
            if (existName)
            {
                ModelState.AddModelError("Name", "This brand exists");
                return View();
            }

            var newBrand = new Brand
            {
                Name = brandCreateVM.Name.ToLower(),
                ImageUrl= fileName
            };

            await _context.AddAsync(newBrand);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public  IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            var dbBrand =  _context.Brands.FirstOrDefault(c=>c.Id == id);
            if (dbBrand == null) return NotFound();
            return View(dbBrand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, BrandUpdateVM brandUpdateVM)
        {

            if (id == null) return NotFound();
            var dbBrand =  _context.Brands.FirstOrDefault(c=>c.Id == id);
            if (dbBrand == null) return NotFound();

            if (!ModelState.IsValid) return View();

            if (brandUpdateVM.Image!=null)
            {
                if (ModelState["Image"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }

                if (!brandUpdateVM.Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }

                if (brandUpdateVM.Image.MaxLength(2000))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                    return View();
                }


                string path = Path.Combine("assets", "img", "brand");
                Helper.DeleteImage(_env.WebRootPath, path, dbBrand.ImageUrl);
                string fileName = await brandUpdateVM.Image.SaveImg(_env.WebRootPath, path);

                dbBrand.ImageUrl = fileName;
            }

            var existBrand =  _context.Brands.FirstOrDefault(x=>x.Name == brandUpdateVM.Name);
            if(existBrand!= null)
            {
                if(dbBrand != existBrand)
                {
                    ModelState.AddModelError("Name", "Bu adda Brand movcuddur");
                    return View();
                }
            }

            dbBrand.Name = brandUpdateVM.Name;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var brand = _context.Brands.FirstOrDefault(c => c.Id == id);
            if (brand == null) return NotFound();
            brand.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}