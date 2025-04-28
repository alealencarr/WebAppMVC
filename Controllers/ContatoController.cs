using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
