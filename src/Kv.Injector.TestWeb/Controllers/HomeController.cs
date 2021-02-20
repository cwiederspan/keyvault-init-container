using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kv.Injector.TestWeb.Models;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Configuration;

namespace Kv.Injector.TestWeb.Controllers {

    public class HomeController : Controller {

        private readonly IConfiguration Configuration;

        public HomeController(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        public IActionResult Index() {
            this.ViewData["Message"] = this.Configuration.GetValue<string>("KvInjector") ?? "Welcome";
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
