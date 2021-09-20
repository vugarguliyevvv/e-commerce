using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace XanElectronics.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}