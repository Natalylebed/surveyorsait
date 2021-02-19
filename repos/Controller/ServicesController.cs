using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repos.Domeins;

namespace repos.Controller
{
    public class ServicesController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly DataManager dataManager;
        public ServicesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if(id !=default)
            { 
                return View("Show", dataManager.ServiceItems.GetServiceItemByID(id)); 
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServises");
            return View(dataManager.ServiceItems.GetServiceItems());
        }
        
    }
}

