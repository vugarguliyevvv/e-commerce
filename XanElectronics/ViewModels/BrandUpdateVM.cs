using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace XanElectronics.ViewModels
{
    public class BrandUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}