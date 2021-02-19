using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repos.Servises;
using repos.Domeins;
using repos.Domeins.Entities;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace repos.Areas.Admin.Controller
{
    [Area("Admin")]
    public class ServiceItemsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnviroment;
        public ServiceItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnviroment = hostingEnvironment;
        }
        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new ServiceItem() : dataManager.ServiceItems.GetServiceItemByID(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(ServiceItem model, IFormFile titleImagefile)
        {
            if (ModelState.IsValid)
            {
                if (titleImagefile != null)
                {
                    model.TitleImagePath = titleImagefile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnviroment.WebRootPath , "images/", titleImagefile.FileName), FileMode.Create))
                    {
                        titleImagefile.CopyTo(stream);
                    }
                }
                dataManager.ServiceItems.SaveServiceItem(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.ServiceItems.DeleteServiseItem(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

    }
}
