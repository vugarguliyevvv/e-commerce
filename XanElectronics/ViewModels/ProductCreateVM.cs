using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XanElectronics.ViewModels
{
    public class ProductCreateVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int DisCountRate { get; set; }
        [Required]
        public int Star { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        [Required]
        public string LongDescription { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public bool IsOriginal { get; set; }
        public string Color { get; set; }
        public int Count { get; set; }
        public string Size { get; set; }
        public string Code { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [NotMapped,Required]
        public IFormFile[] Images { get; set; }
    }
}
