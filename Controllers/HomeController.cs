using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C_Sharp_RandomPasscode.Models;
// For Sessions:
using Microsoft.AspNetCore.Http;

namespace C_Sharp_RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("passcodeCount", 1);
            int? Count = HttpContext.Session.GetInt32("passcodeCount");
            ViewBag.passcodeCount = Count;
            return View("Index");
        }

        [HttpPost("")]
        public IActionResult Generate()
        {
            int? Count = HttpContext.Session.GetInt32("passcodeCount");
            HttpContext.Session.SetInt32("passcodeCount", (int)Count+1);
            int? num_count = HttpContext.Session.GetInt32("passcodeCount");
            ViewBag.passcodeCount = num_count;
            // Console.WriteLine("**************");
            // Console.WriteLine(ViewBag.passcodeCount);
            // Console.WriteLine("**************");
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string passcodeResult = "";
            Random Rand = new Random();
            for (int i=0; i<14; i++)
            {
                passcodeResult = passcodeResult + (chars[Rand.Next(0, chars.Length)]);
            }
            ViewBag.passcodeNew = passcodeResult;
            return View("Index");
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
