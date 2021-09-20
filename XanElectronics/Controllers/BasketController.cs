using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using XanElectronics.Dal;
using XanElectronics.Models;
using XanElectronics.ViewModels;

namespace XanElectronics.Controllers
{
    public class BasketController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        public BasketController(DataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            decimal number = 0;
            ViewBag.BasketTotalPrice = "";
            string xbasket = Request.Cookies["xbasket"];
            List<BasketVM> basketProducts = new List<BasketVM>();
            List<BasketVM> userProducts = new List<BasketVM>();

            if (xbasket != null)
            {
                basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(xbasket);

                foreach (BasketVM basketProduct in basketProducts)
                {
                    if (basketProduct.UserName == User.Identity.Name)
                    {
                        Product dbProduct = _context.Products.Include(p=>p.ProductImages).FirstOrDefault(x => x.Id == basketProduct.Id);
                        if (dbProduct != null)
                        {
                            basketProduct.Price = dbProduct.ResultPrice;
                            basketProduct.Image = dbProduct.ProductImages.FirstOrDefault().ImageUrl;
                            basketProduct.Title = dbProduct.Name;
                            basketProduct.DbCount = dbProduct.Count;
                            userProducts.Add(basketProduct);
                        }
                        basketProduct.ProductTotalPrice = basketProduct.BasketCount * basketProduct.Price;
                        number += basketProduct.ProductTotalPrice;
                    }
                }
               
                ViewBag.BasketTotalPrice = number;
            }
            return View(userProducts);
        }


        public IActionResult AddBasket([FromForm] int addProductCount, int id)
        {
            decimal basketTotalPrice = 0;

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            Product dbproduct = _context.Products.FirstOrDefault(x => x.Id == id);

            if (dbproduct == null) return NotFound();
            List<BasketVM> basketProducts;
            if (Request.Cookies["xbasket"] == null)
            {
                basketProducts = new List<BasketVM>();
            }
            else
            {
                basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["xbasket"]);
            }

            BasketVM existProduct = basketProducts.FirstOrDefault(p => p.Id == id && p.UserName == User.Identity.Name);

            if (existProduct == null)
            {
                BasketVM newproduct = new BasketVM
                {
                    Id = dbproduct.Id,
                    UserName = User.Identity.Name,
                    BasketCount = 1
                };
                if (addProductCount!=0)
                {
                    newproduct.BasketCount = addProductCount;
                }
                basketProducts.Add(newproduct);
            }
            else
            {
                if (addProductCount != 0)
                {
                    existProduct.BasketCount += addProductCount;
                }
                else
                {
                    existProduct.BasketCount++;
                }
            }

            foreach (var basketProduct in basketProducts.Where(x => x.UserName == User.Identity.Name))
            {
                Product dbProduct = _context.Products.Include(p=>p.ProductImages).FirstOrDefault(x => x.Id == basketProduct.Id);
                if (dbProduct != null)
                {
                    basketProduct.Price = dbProduct.ResultPrice;
                    basketProduct.Image = dbProduct.ProductImages.FirstOrDefault().ImageUrl;
                    basketProduct.Title = dbProduct.Name;
                    basketProduct.DbCount = dbProduct.Count;
                }
                basketProduct.ProductTotalPrice = basketProduct.BasketCount * basketProduct.Price;
                basketTotalPrice += basketProduct.ProductTotalPrice;
            }

            string xbasket = JsonConvert.SerializeObject(basketProducts);
            Response.Cookies.Append("xbasket", xbasket, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            var anonymObject = new
            {
                BasketTotalPrice = basketTotalPrice,
                BasketProductCount = basketProducts.Where(p => p.UserName == User.Identity.Name).Count()
            };

            return Ok(anonymObject);
        }


        public IActionResult ProductCountPlusAxious([FromForm] int id)
        {
            int basketProductDbCount = 0;
            decimal basketTotalPrice = 0;
            decimal productTotalPrice = 0;
            string basket = Request.Cookies["xbasket"];
            List<BasketVM> basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM product = basketProducts.FirstOrDefault(p => p.Id == id && p.UserName == User.Identity.Name);

            product.BasketCount++;
            int basketCount = product.BasketCount;
            foreach (var basketProduct in basketProducts.Where(x => x.UserName == User.Identity.Name))
            {
                Product dbProduct = _context.Products.Include(p=>p.ProductImages).
                    FirstOrDefault(x => x.Id == basketProduct.Id);

                if (dbProduct != null)
                {
                    basketProduct.Price = dbProduct.ResultPrice;
                    basketProduct.Image = dbProduct.ProductImages.FirstOrDefault().ImageUrl;
                    basketProduct.Title = dbProduct.Name;
                    basketProduct.DbCount = dbProduct.Count;
                }

                if (dbProduct.Id == id)
                {
                    basketProductDbCount = dbProduct.Count;
                }
                
                basketProduct.ProductTotalPrice = basketProduct.BasketCount * basketProduct.Price;
                if (basketProduct.Id == id)
                {
                    productTotalPrice = basketProduct.ProductTotalPrice;
                }
                basketTotalPrice += basketProduct.ProductTotalPrice;
            }

            string xbasket = JsonConvert.SerializeObject(basketProducts);
            Response.Cookies.Append("xbasket", xbasket, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            var anonymObject = new
            {
                BasketProducts = basketProducts,
                ProductBasketCount = basketCount,
                BasketTotalPrice = basketTotalPrice,
                ProductTotalPrice = productTotalPrice,
                BasketProductDbCount = basketProductDbCount,
                ProductId = product.Id
            };
            return Ok(anonymObject);
        }

        public IActionResult ProductCountMinusAxious(int? id)
        {
            decimal basketTotalPrice = 0;
            decimal productTotalPrice = 0;
            string basket = Request.Cookies["xbasket"];
            List<BasketVM> basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM product = basketProducts.FirstOrDefault(p => p.Id == id);

            if (product.BasketCount > 1)
            {
                product.BasketCount--;
            }
            else
            {
                basketProducts.Remove(product);
            }

            int basketCount = product.BasketCount;
            foreach (var basketProduct in basketProducts.Where(x => x.UserName == User.Identity.Name))
            {
                Product dbProduct = _context.Products.Include(p=>p.ProductImages).
                    FirstOrDefault(x => x.Id == basketProduct.Id);
                if (dbProduct != null)
                {
                    basketProduct.Price = dbProduct.ResultPrice;
                    basketProduct.Image = dbProduct.ProductImages.FirstOrDefault().ImageUrl;
                    basketProduct.Title = dbProduct.Name;
                    basketProduct.DbCount = dbProduct.Count;
                }
                basketProduct.ProductTotalPrice = basketProduct.BasketCount * basketProduct.Price;
                if (basketProduct.Id == id)
                {
                    productTotalPrice = basketProduct.ProductTotalPrice;
                }
                basketTotalPrice += basketProduct.ProductTotalPrice;
            }

            string xbasket = JsonConvert.SerializeObject(basketProducts);
            Response.Cookies.Append("xbasket", xbasket, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            var anonymObject = new
            {
                BasketProducts = basketProducts,
                ProductBasketCount = basketCount,
                BasketTotalPrice = basketTotalPrice,
                ProductTotalPrice = productTotalPrice
            };
            return Ok(anonymObject);
        }


        public IActionResult RemoveProduct(int id)
        {
            decimal basketTotalPrice = 0;
            string basket = Request.Cookies["xbasket"];
            List<BasketVM> basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            
            BasketVM product = basketProducts.Where(p => p.UserName == User.Identity.Name)
                .FirstOrDefault(p => p.Id == id);
            basketProducts.Remove(product);
            foreach (var basketProduct in basketProducts.Where(p=>p.UserName==User.Identity.Name))
            {
                basketProduct.ProductTotalPrice = basketProduct.BasketCount * basketProduct.Price;
                basketTotalPrice += basketProduct.ProductTotalPrice;
            }
            
            string xbasket = JsonConvert.SerializeObject(basketProducts);
            Response.Cookies.Append("xbasket", xbasket, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            var anonymObject = new
            {
                BasketTotalPrice = basketTotalPrice,
                BasketProductCount = basketProducts.Where(x => x.UserName == User.Identity.Name).Count()
            };
            return Ok(anonymObject);
        }

        public IActionResult BasketSale()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BasketSale(Sale checkOutInfo)
        {
            if (!ModelState.IsValid) return View();
            
            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
                Sale sale = new Sale
                {
                    Date = DateTime.Now,
                    AppUserId = appUser.Id,
                    FullName=checkOutInfo.FullName,
                    Phone=checkOutInfo.Phone,
                    Email=checkOutInfo.Email,
                    Address=checkOutInfo.Address,
                    IsFinished = false
                };
                List<BasketVM> basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["xbasket"]);

                foreach (BasketVM item in basketProducts)
                {
                    var dbPro = await _context.Products.FindAsync(item.Id);
                    if (item.BasketCount > dbPro.Count)
                    {
                        return Content("Get qumla oyna");
                    }
                }
                List<SaleProduct> saleProducts = new List<SaleProduct>();
                decimal total = 0;
                foreach (BasketVM basketProduct in basketProducts.Where(p=>p.UserName==User.Identity.Name))
                {
                    if (basketProduct.UserName == User.Identity.Name)
                    {
                        Product dbProduct = await _context.Products.FindAsync(basketProduct.Id);

                        dbProduct.Count -= basketProduct.BasketCount;
                        await _context.SaveChangesAsync();

                        SaleProduct saleProduct = new SaleProduct
                        {
                            Price = dbProduct.ResultPrice,
                            Count = basketProduct.BasketCount,
                            ProductId = basketProduct.Id,
                            SaleId = sale.Id
                        };
                        total += saleProduct.Price * saleProduct.Count;
                        saleProducts.Add(saleProduct);
                    }

                }
                sale.Total = total;
                sale.SaleProducts = saleProducts;

                await _context.Sales.AddAsync(sale);
                await _context.SaveChangesAsync();
                foreach (var item in basketProducts.Where(p => p.UserName == User.Identity.Name).ToList())
                {
                    basketProducts.Remove(item);

                }
                string xbasket = JsonConvert.SerializeObject(basketProducts);
                Response.Cookies.Append("xbasket", xbasket, new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
                TempData["success"] = "Sifarishiniz ugurla yerine yetirildi, bizi sechdiyiniz uchun teshekkurler..";
                return RedirectToAction("Index", "Basket");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
