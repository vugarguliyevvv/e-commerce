using System.Collections.Generic;
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
using XanElectronics.Services;
using XanElectronics.ViewModels;

namespace XanElectronics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET
        public IActionResult Index()
        {
            return View(_context.Categories.Where(x=>x.IsDeleted==false).ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM categoryCreateVM)
        {
            if (!ModelState.IsValid) return View();

            if (ModelState["Image"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!categoryCreateVM.Image.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }

            if (categoryCreateVM.Image.MaxLength(2000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                return View();
            }


            string path = Path.Combine("assets", "img", "category");
            string fileName = await categoryCreateVM.Image.SaveImg(_env.WebRootPath, path);

            bool existName = _context.Categories.Any(c => c.Name.ToLower().Trim() == categoryCreateVM.Name.ToLower().Trim());
            if (existName)
            {
                ModelState.AddModelError("Name", "This category exists");
                return View();
            }

            Category newCategory = new Category
            {
                Name = categoryCreateVM.Name.ToLower(),
                ImageUrl= fileName
            };

            // var callbackUrl = Url.Action(
            //        "Home",
            //        "Index",
            //        new { Id = categoryCreateVM.Id },
            //        protocol: HttpContext.Request.Scheme);
            // EmailService email = new EmailService();
            // List<string> e = _context.Subscriptions.Select(x => x.Email).ToList();
            // await email.SendEmailAsync(e, "Yeni event",
            //        "Yeni event: <a href=https://localhost:44349/Home/Index/" + $"{newCategory.Id}" + ">link</a>");

            await _context.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public  IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Category dbCategory =  _context.Categories.FirstOrDefault(c=>c.Id == id);
            if (dbCategory == null) return NotFound();
            return View(dbCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, CategoryUpdateVM categoryUpdateVM)
        {

            if (id == null) return NotFound();
            Category dbCategory =  _context.Categories.FirstOrDefault(c=>c.Id == id);
            if (dbCategory == null) return NotFound();

            if (!ModelState.IsValid) return View();

            if (categoryUpdateVM.Image!=null)
            {
                if (ModelState["Image"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }

                if (!categoryUpdateVM.Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }

                if (categoryUpdateVM.Image.MaxLength(2000))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                    return View();
                }


                string path = Path.Combine("assets", "img", "category");
                Helper.DeleteImage(_env.WebRootPath, path, dbCategory.ImageUrl);
                string fileName = await categoryUpdateVM.Image.SaveImg(_env.WebRootPath, path);

                dbCategory.ImageUrl = fileName;
            }

            Category existCategory =  _context.Categories.FirstOrDefault(x=>x.Name == categoryUpdateVM.Name);
            if(existCategory!= null)
            {
                if(dbCategory != existCategory)
                {
                    ModelState.AddModelError("Name", "Bu adda Category movcuddur");
                    return View();
                }
            }

            dbCategory.Name = categoryUpdateVM.Name;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            category.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}