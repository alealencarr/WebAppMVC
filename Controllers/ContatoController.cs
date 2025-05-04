using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Data;
using WebAppMVC.Models;
using WebAppMVC.Repositorio;
using WebAppMVC.Utils;

namespace WebAppMVC.Controllers
{
    public class ContatoController : Controller
    {        
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            var allContacts = _contatoRepositorio.GetAllContacts();
            return View(allContacts);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            return View(_contatoRepositorio.GetById(id));
        }


        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(contato);
                }                

                _contatoRepositorio.Alterar(contato);
                
                MessageHelper.SetMessageSucess(this, "Alteração realizada com sucesso!");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                MessageHelper.SetMessageError(this, "Erro ao realizar alteraçao:" + ex.Message);
                return View(contato);
            }
        }

        [HttpPost]
        public IActionResult Apagar(int id)
        {
            try
            {
                _contatoRepositorio.Apagar(id);
                MessageHelper.SetMessageSucess(this, "Exclusão realizada com sucesso!");

                return RedirectToAction("Index");
 
            }
            catch (Exception ex)
            {
                MessageHelper.SetMessageError(this, "Erro ao realizar exclusão:" + ex.Message);
                return RedirectToAction("Index");
            }

       
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(contato);
                }

                _contatoRepositorio.Adicionar(contato);
                MessageHelper.SetMessageSucess(this, "Inclusão realizada com sucesso!");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                MessageHelper.SetMessageError(this, "Erro ao realizar alteraçao:" + ex.Message);
                return View(contato);
            }
        }
    }
}
