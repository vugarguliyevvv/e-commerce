using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XanElectronics.Dto
{
    public class ProductReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal ResultPrice { get; set; }
        public int DisCountRate { get; set; }
        public int Star { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public string Category { get; set; }
        public ICollection<string> ProductImages { get; set; }
    }
}
