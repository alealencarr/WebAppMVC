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
        private readonly IEmail _email;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
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

         
        public IActionResult RedefinirSenha()
        {
            return View();

        }
        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index");
                }

                var user = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                if (user is null)
                {
                    MessageHelper.SetMessageError(this, $"Dados inválidos, usuário não encontrado.");
                    return View("Index");
                }

                string novaSenha = user.GerarNovaSenha();

                bool emailEnviado = _email.Enviar(user.Email, "Sistema de Contatos - Nova Senha", $"Sua nova senha é: {novaSenha}");

                if (emailEnviado)
                {
                    _usuarioRepositorio.Alterar(user);
                    MessageHelper.SetMessageSucess(this, "Enviamos para o seu e-mail cadastrado uma nova senha.");
                }
                else
                {
                    MessageHelper.SetMessageError(this, $"Não conseguimos enviar sua nova senha para o seu e-mail, por favor, verifique os dados informados e tente novamente");
                }


                return RedirectToAction("Index", "Login");

            }
            catch (Exception ex)
            {
                MessageHelper.SetMessageError(this, $"Ops, não conseguimos redefinir sua senha, tente novamente, detahe do erro: {ex.Message}");
                return View("Index");
            }

        }
    }
}
