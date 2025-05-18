using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WebAppMVC.Models;

namespace WebAppMVC.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUser = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUser)) return null;

            UsuarioModel user = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUser); 

            return View(user);
        }
    }
}
