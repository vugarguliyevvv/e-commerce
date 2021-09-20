using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XanElectronics.ViewModels
{
    public class BasketVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int BasketCount { get; set; } = 1;
        public int DbCount { get; set; }
        public int TotalBasketCount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public string UserName { get; set; }
    }
}
