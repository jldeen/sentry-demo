using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sentrydemo.Models;
using SharpRaven;

namespace sentrydemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";  
                var ravenClient = new RavenClient("https://d1974c49653f4ed79e93bc22f711ac98@sentry.io/1266508");
                ravenClient.Capture(new SharpRaven.Data.SentryEvent("About page clicked!"));
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            var ravenClient = new RavenClient           
                ("https://d1974c49653f4ed79e93bc22f711ac98@sentry.io/1266508");
                try {
                    var x = 3;
                    var y = 0;
                    var z = x/y;
                }
                catch(Exception e) {
                    ravenClient.Capture(new SharpRaven.Data.SentryEvent(e));
                }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
