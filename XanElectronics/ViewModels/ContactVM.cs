using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XanElectronics.Models;

namespace XanElectronics.ViewModels
{
    public class ContactVM
    {
        public Bio Bio { get; set; }
        public MessageCreateVM MessageCreateVM { get; set; }
    }
}
