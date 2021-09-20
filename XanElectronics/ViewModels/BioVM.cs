using System.Collections.Generic;
using XanElectronics.Models;

namespace XanElectronics.ViewModels
{
    public class BioVM
    {
        public Bio Bio { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}