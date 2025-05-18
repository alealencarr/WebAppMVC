using Newtonsoft.Json;
using System.Drawing;
using System.Text.Json.Serialization;
using WebAppMVC.Models;

namespace WebAppMVC.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public void CriarSessaoDoUser(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public UsuarioModel GetSessaoUsuario()
        {
           string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
                return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

        }

        public void RemoverSessaoDoUser()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
