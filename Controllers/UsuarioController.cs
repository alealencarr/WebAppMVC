using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Filters;
using WebAppMVC.Models;
using WebAppMVC.Repositorio;
using WebAppMVC.Utils;

namespace WebAppMVC.Controllers
{
    [PaginaRestritaSomenteAdmin]

    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.GetAllUsers();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return View(usuario);
                }

                _usuarioRepositorio.Adicionar(usuario);
                MessageHelper.SetMessageSucess(this, "Inclusão realizada com sucesso!");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                MessageHelper.SetMessageError(this, "Erro ao realizar inclusão:" + ex.Message);
                return View(usuario);
            }
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            UsuarioModel user = _usuarioRepositorio.GetById(id);
            user.IsEdicao();

            return View(user);
        }


        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(usuario);
                }

                _usuarioRepositorio.Alterar(usuario);

                MessageHelper.SetMessageSucess(this, "Alteração realizada com sucesso!");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                MessageHelper.SetMessageError(this, "Erro ao realizar alteraçao:" + ex.Message);
                return View(usuario);
            }
        }

        [HttpPost]
        public IActionResult Apagar(int id)
        {
            try
            {
                _usuarioRepositorio.Apagar(id);
                MessageHelper.SetMessageSucess(this, "Exclusão realizada com sucesso!");

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                MessageHelper.SetMessageError(this, "Erro ao realizar exclusão:" + ex.Message);
                return RedirectToAction("Index");
            }


        }
    }
}
