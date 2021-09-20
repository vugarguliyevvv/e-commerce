using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XanElectronics.Dal;
using XanElectronics.Models;

namespace XanElectronics.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly DataContext _context;
        public FooterViewComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Bio model = _context.Bios.FirstOrDefault();
            return View(await Task.FromResult(model));
        }
    }
}
