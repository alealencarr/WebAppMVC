using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Helper;
using WebAppMVC.Models;
using WebAppMVC.Repositorio;
using WebAppMVC.Utils;

namespace WebAppMVC.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenha)
        {
            try
            {
                UsuarioModel user = _sessao.GetSessaoUsuario();
                alterarSenha.Id = user.Id;
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AlterarSenha(alterarSenha);
                    Utils.MessageHelper.SetMessageSucess(this, "Senha alterada com sucesso.");
                    return View("Index", alterarSenha);
                }

                return View("Index", alterarSenha);

            }
            catch
            (Exception ex)
            {
                MessageHelper.SetMessageError(this, $"Erro ao alterar senha:{ex.Message}");
                return View("Index", alterarSenha);

            }

        }
    }
}
