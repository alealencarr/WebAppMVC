using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Helper;
using WebAppMVC.Models;
using WebAppMVC.Repositorio;
using WebAppMVC.Utils;

namespace WebAppMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.GetSessaoUsuario() is not null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUser();
            return View("Index");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginUser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index");
                }

                var user = _usuarioRepositorio.BuscarPorLogin(loginUser.Login);

                if (user is null)
                {
                    MessageHelper.SetMessageError(this, $"E-mail inválido, usuário não encontrado.");
                    return View("Index");
                }

                if (!user.SenhaValida(loginUser.Senha))
                {
                    MessageHelper.SetMessageError(this, $"Senha incorreta.");
                    return View("Index");
                }
                _sessao.CriarSessaoDoUser(user);
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                MessageHelper.SetMessageError(this, $"Erro ao realizar login: {ex.Message}");
                return View("Index");
            }
        }
    }
}
