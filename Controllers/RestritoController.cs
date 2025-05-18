using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Filters;

namespace WebAppMVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
