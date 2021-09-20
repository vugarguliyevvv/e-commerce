using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XanElectronics.Models
{
    public class Bio
    {
        public int Id { get; set; }
        public string HeaderLogoUrl { get; set; }
        [NotMapped]
        public IFormFile HeaderLogo { get; set; }
        public string FooterLogoUrl { get; set; }
        [NotMapped]
        public IFormFile FooterLogo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
    }
}
