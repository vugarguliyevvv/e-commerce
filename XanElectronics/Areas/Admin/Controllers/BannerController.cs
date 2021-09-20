using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XanElectronics.Dal;
using XanElectronics.Extentions;
using XanElectronics.Helpers;
using XanElectronics.Models;
using XanElectronics.ViewModels;

namespace XanElectronics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BannerController : Controller
    {

        private readonly DataContext _context;
        private readonly IHostingEnvironment _env;
        public BannerController(DataContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Banners.ToList());
        }



        public IActionResult Create()
        {
            if (_context.Banners.Count() >= 5)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Banner banner)
        {

            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!banner.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }

            if (banner.Photo.MaxLength(2000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                return View();
            }

            if (_context.Sliders.Count() >= 5)
            {
                return RedirectToAction(nameof(Index));
            }
            string path = Path.Combine("assets", "img", "banner");
            string fileName = await banner.Photo.SaveImg(_env.WebRootPath, path);

            Banner newslider = new Banner();
            newslider.Image = fileName;

            await _context.Banners.AddAsync(newslider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Banner slider = await _context.Banners.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Banner slider = await _context.Banners.FindAsync(id);
            if (slider == null) return NotFound();
            string path = Path.Combine("assets", "img", "banner");
            Helper.DeleteImage(_env.WebRootPath, path, slider.Image);

            _context.Banners.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            var banner = await _context.Banners.FindAsync(id);
            if (banner == null) return NotFound();
            return View(banner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, CreateBannerVM createBannerVM)
        {
            if (id == null) return NotFound();
            var dbBanner = await _context.Banners.FindAsync(id);
            if (dbBanner == null) return NotFound();
            if (createBannerVM.Photo != null)
            {
                if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    return View();
                }

                if (!createBannerVM.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }

                if (createBannerVM.Photo.MaxLength(200))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                    return View();
                }


                string path = Path.Combine("assets", "img", "banner");
                Helper.DeleteImage(_env.WebRootPath, path, dbBanner.Image);


                string fileName = await createBannerVM.Photo.SaveImg(_env.WebRootPath, path);
                dbBanner.Image = fileName;

            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
