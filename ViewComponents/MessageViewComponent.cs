 
using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.ViewComponents
{
    public class MessageViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var msg = TempData["MessageText"] as string;
            var type = TempData["MessageType"] as string;

            if (msg == null) return Content(string.Empty);

            return View("Default", (type, msg));
        }
    }

}