using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace XanElectronics.ViewModels
{
    public class BrandCreateVM
    {
        [Required]
        public string Name { get; set; }
        [NotMapped,Required]
        public IFormFile Image { get; set; }
    }
}