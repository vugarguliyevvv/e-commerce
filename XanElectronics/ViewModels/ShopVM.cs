using System.Collections;
using System.Collections.Generic;
using XanElectronics.Models;

namespace XanElectronics.ViewModels
{
    public class ShopVM
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Brand> Brands { get; set; }
    }
}