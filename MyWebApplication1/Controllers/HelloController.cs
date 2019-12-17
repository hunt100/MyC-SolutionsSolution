using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApplication1
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            try
            {
                HttpContext.Session.SetString("username", User.Identity.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured" + e);
            }
            TempData["tempStatus"] = "TEMP CREATED";
            return View("Index2");
        }

        public IActionResult About()
        {
            
            ViewData["usersession"] = HttpContext.Session.GetString("username"); 
            return View();
        }

    }
}
