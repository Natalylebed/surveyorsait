using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repos.Domeins.Entities;
using repos.Domeins;
using repos.Servises;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace repos.Areas.Admin.Controller
{
    [Area("Admin")]
    public class TextFieldsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnviroment;
        public TextFieldsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnviroment = hostingEnvironment;
        }
        public IActionResult Edit(string codeWord)
        {
            var entity = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }
        [HttpPost]
        
        public IActionResult Edit(TextField model, IFormFile titleImagefile2)
        {
            if (ModelState.IsValid)
            {
                if (titleImagefile2 != null)
                {
                    model.TitleImagePath = titleImagefile2.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnviroment.WebRootPath, "images/", titleImagefile2.FileName), FileMode.Create))
                    {
                        titleImagefile2.CopyTo(stream);
                    }
                }
                dataManager.TextFields.SaveTextField(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

    }
}
