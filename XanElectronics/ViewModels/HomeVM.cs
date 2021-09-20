using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XanElectronics.Models;

namespace XanElectronics.ViewModels
{
    public class HomeVM
    {
        public ICollection<Product> Products { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Slider> Sliders { get; set; }
        public ICollection<Banner> Banners { get; set; }
    }
}
