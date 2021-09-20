using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XanElectronics.Dto
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal ResultPrice { get; set; }
        public int DisCountRate { get; set; }
        public int Star { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public bool IsOriginal { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Code { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public IFormFile[] Images { get; set; }

    }
}
