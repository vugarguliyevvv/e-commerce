using Microsoft.AspNetCore.Http;

namespace XanElectronics.ViewModels
{
    public class CreateSliderVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        
        public IFormFile Photo { get; set; }
    }
}