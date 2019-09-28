using Microsoft.AspNetCore.Mvc;

namespace MyWebApplication1
{
    public class CalculatorController : Controller
    {
        // GET
        public IActionResult PlusTen(int number)
        {
            ViewData["number"] = number;
            ViewData["result"] = number + 10;

            return View("PlusTen");
        }
    }
}