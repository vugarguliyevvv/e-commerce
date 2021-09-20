using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using XanElectronics.Dal;
using XanElectronics.Extentions;
using XanElectronics.Helpers;
using XanElectronics.Models;
using XanElectronics.ViewModels;

namespace XanElectronics.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {

        private readonly DataContext _context;
        private readonly IHostingEnvironment _env;
        public SliderController(DataContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
             return View(_context.Sliders.ToList());
        }
        
       

        public IActionResult Create()
        {
            if (_context.Sliders.Count() >= 5)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(Slider slider)
        {
           
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                return View();
            }

            if (slider.Photo.MaxLength(2000))
            {
                ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                return View();
            }

            if (_context.Sliders.Count() >= 5)
            {
                return RedirectToAction(nameof(Index));
            }
            string path = Path.Combine("assets","img", "slider");
            string fileName = await slider.Photo.SaveImg(_env.WebRootPath, path);
            
            Slider newslider = new Slider();
            newslider.Description= slider.Description;          
            newslider.Title = slider.Title;
            newslider.Image = fileName;
            
            await _context.Sliders.AddAsync(newslider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            string path = Path.Combine("assets","img", "slider");
            Helper.DeleteImage(_env.WebRootPath, path, slider.Image);

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            return View(slider);
        }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Update(int? id, CreateSliderVM createSliderVM)
         {
             if (id == null) return NotFound();
             Slider dbSlider = await _context.Sliders.FindAsync(id);
             if (dbSlider == null) return NotFound();
             if (createSliderVM.Photo != null)
             {
                 if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                 {
                     return View();
                 }
        
                 if (!createSliderVM.Photo.IsImage())
                 {
                     ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                     return View();
                 }
        
                 if (createSliderVM.Photo.MaxLength(200))
                 {
                     ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                     return View();
                 }
        
        
                 string path = Path.Combine("assets","img", "slider");
                 Helper.DeleteImage(_env.WebRootPath, path, dbSlider.Image);
              
        
                 string fileName = await createSliderVM.Photo.SaveImg(_env.WebRootPath, path);
                 dbSlider.Image = fileName;
        
             }
             dbSlider.Description = createSliderVM.Description;
             dbSlider.Title = createSliderVM.Title;
             
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
        }
    }

}