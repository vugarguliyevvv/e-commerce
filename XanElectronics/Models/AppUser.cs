using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XanElectronics.Models
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
        public ICollection<Sale> Sales { get; set; }

    }
}
