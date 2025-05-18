using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using WebAppMVC.Models;

namespace WebAppMVC.Filters
{
    public class PaginaParaUsuarioLogado : ActionFilterAttribute
    {
     

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUser = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUser))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                UsuarioModel user = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUser);

                if (user == null) context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });


            }

            base.OnActionExecuting(context);
        }

    }
}
