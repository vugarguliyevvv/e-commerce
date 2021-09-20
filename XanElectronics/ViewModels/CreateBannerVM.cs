using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XanElectronics.ViewModels
{
    public class CreateBannerVM
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public IFormFile Photo { get; set; }
    }
}
