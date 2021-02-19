using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repos.Domeins.Repository;
using repos.Domeins;
using repos.Domeins.Repository.Abstract;

namespace repos.Areas.Admin.Controller
{
    [Area("Admin")]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.ServiceItems.GetServiceItems());
        }
    }
}
