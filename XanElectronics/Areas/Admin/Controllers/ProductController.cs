using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XanElectronics.Dal;
using XanElectronics.Dto;
using XanElectronics.Extentions;
using XanElectronics.Models;
using XanElectronics.ViewModels;

namespace XanElectronics.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public ProductController(DataContext context, IWebHostEnvironment env, IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
        }
        // GET
        public IActionResult Index(int? page)
        {
            ViewBag.PageCount = Math.Ceiling((decimal)_context.Products.Count()/5);
            ViewBag.Page = page;
            if (page == null)
            {
                return View(_context.Products.Where(x => x.IsDeleted == false)
                    .Include(x => x.ProductImages)
                    .Include(x => x.Brand)
                    .Include(x => x.Category)
                    .OrderByDescending(p => p.Id).Take(5).ToList());
            }
            else
            {
                return View(_context.Products.Where(x => x.IsDeleted == false)
                    .Include(x => x.ProductImages)
                    .Include(x => x.Brand)
                    .Include(x => x.Category)
                    .OrderByDescending(p => p.Id).Skip(((int)page-1)*5).Take(5).ToList());
            }
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


        public IActionResult Create()
        {
            ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");

            if (!ModelState.IsValid) return View();

            if (ModelState["Images"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            var productImages = new List<ProductImage>();
            foreach (var Image in productCreateVM.Images)
            {
                if (!Image.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                    return View();
                }

                if (Image.MaxLength(2000))
                {
                    ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                    return View();
                }

                string path = Path.Combine("assets", "img", "product");
                string fileName = await Image.SaveImg(_env.WebRootPath, path);
                var productImage = new ProductImage
                {
                    ProductId = productCreateVM.Id,
                    ImageUrl = fileName
                };
                productImages.Add(productImage);
            }

            decimal resultPrice = 0;
            if (productCreateVM.DisCountRate>0)
            {
                resultPrice = productCreateVM.Price - ((productCreateVM.Price * productCreateVM.DisCountRate) / 100);
            }
            else
            {
                resultPrice = productCreateVM.Price;
            }

            Product product = new Product
            {
                Name = productCreateVM.Name,
                IsNew = productCreateVM.IsNew,
                IsFeatured = productCreateVM.IsFeatured,
                Price = productCreateVM.Price,
                Star=productCreateVM.Star,
                DisCountRate = productCreateVM.DisCountRate,
                ResultPrice=resultPrice,
                LongDescription = productCreateVM.LongDescription,
                ShortDescription = productCreateVM.ShortDescription,
                Color = productCreateVM.Color,
                Code = productCreateVM.Code,
                Size = productCreateVM.Size,
                IsOriginal = productCreateVM.IsOriginal,
                Count = productCreateVM.Count,
                CategoryId=productCreateVM.CategoryId,
                BrandId = productCreateVM.BrandId,
                ProductImages=productImages
            };
            var category = _context.Categories.FirstOrDefault(x => x.Id == productCreateVM.CategoryId);
            category.ProductCount++;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int? id)
        {
            ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            if (id == null) return NotFound();
            var product = _context.Products.Include(x=>x.Category).Include(x=>x.ProductImages).FirstOrDefault(c => c.Id == id);
            if (product == null) return NotFound();
            var mapperProduct = _mapper.Map<ProductUpdateDto>(product);
            return View(mapperProduct);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,ProductUpdateDto productUpdateDto)
        {
            ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            if (id == null) return NotFound();
            var product = _context.Products.Include(x => x.Category).Include(x => x.ProductImages).FirstOrDefault(c => c.Id == id);
            if (product == null) return NotFound();

            if (!ModelState.IsValid) return View();

            
            var productImages = new List<ProductImage>();
            if (productUpdateDto.Images!=null)
            {
                string path = Path.Combine("assets", "img", "product");
                foreach (var item in _context.ProductImages.Where(x => x.ProductId == id).ToList())
                {
                    _context.ProductImages.Remove(item);
                    Helpers.Helper.DeleteImage(_env.WebRootPath,path,item.ImageUrl);
                }
                foreach (var Image in productUpdateDto.Images)
                {
                    if (!Image.IsImage())
                    {
                        ModelState.AddModelError("Photo", "Zehmet olmasa shekil formati sechin");
                        return View();
                    }

                    if (Image.MaxLength(2000))
                    {
                        ModelState.AddModelError("Photo", "Shekilin olchusu max 200kb ola biler");
                        return View();
                    }

                    
                    string fileName = await Image.SaveImg(_env.WebRootPath, path);
                    var productImage = new ProductImage
                    {
                        ProductId = productUpdateDto.Id,
                        ImageUrl = fileName
                    };
                    productImages.Add(productImage);
                }
            }

            decimal resultPrice = 0;
            if (product.DisCountRate!=productUpdateDto.DisCountRate)
            {
                resultPrice = productUpdateDto.Price - ((productUpdateDto.Price * productUpdateDto.DisCountRate) / 100);
            }
            else
            {
                resultPrice = product.Price;
            }

            if (product.CategoryId != productUpdateDto.CategoryId)
            {
                var oldCategory = _context.Categories.FirstOrDefault(x => x.Id == product.CategoryId);
                oldCategory.ProductCount--;

                var newCategory = _context.Categories.FirstOrDefault(x => x.Id == productUpdateDto.CategoryId);
                newCategory.ProductCount++;
            }

            product.Name = productUpdateDto.Name;
            product.Price = productUpdateDto.Price;
            product.Color = productUpdateDto.Color;
            product.Code = productUpdateDto.Code;
            product.IsOriginal = productUpdateDto.IsOriginal;
            product.IsNew = productUpdateDto.IsNew;
            product.IsFeatured = productUpdateDto.IsFeatured;
            product.LongDescription = productUpdateDto.LongDescription;
            product.ShortDescription = productUpdateDto.ShortDescription;
            product.Star = productUpdateDto.Star;
            product.DisCountRate = productUpdateDto.DisCountRate;
            product.ResultPrice = resultPrice;
            product.Count = productUpdateDto.Count;
            product.CategoryId = productUpdateDto.CategoryId;
            product.BrandId = productUpdateDto.BrandId;
            if (productUpdateDto.Images!=null)
            {
                product.ProductImages = productImages;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Products.Include(p => p.Category)
                .Include(c => c.ProductImages)
                .Include(x=>x.Brand).FirstOrDefaultAsync(p => p.Id == id);
            return View(product);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            product.IsDeleted = true;
            var category = _context.Categories.FirstOrDefault(x => x.Id == product.CategoryId);
            category.ProductCount--;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Recover(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            product.IsDeleted = false;
            var category = _context.Categories.FirstOrDefault(x => x.Id == product.CategoryId);
            category.ProductCount++;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DeletedList));
        }

        public IActionResult DeletedList()
        {
            return View(_context.Products.Where(x => x.IsDeleted == true).Include(x => x.ProductImages).
                Include(x => x.Category).ToList());
        }
    }
}