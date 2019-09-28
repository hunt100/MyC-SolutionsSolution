using Microsoft.AspNetCore.Mvc;

namespace MyWebApplication1
{
    [Route("Say")]
    public class MessageController : Controller
    {
        // GET
        [Route("{**message}")]
        public IActionResult ShowMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                ViewData["Message"] = "Message is empty";
            }
            else
            {
                ViewData["Message"] = message;
            }

            return View();
        }
    }
}