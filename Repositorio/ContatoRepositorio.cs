using Microsoft.EntityFrameworkCore;
using WebAppMVC.Data;
using WebAppMVC.Models;

namespace WebAppMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }
        public ContatoModel Adicionar(ContatoModel contato)
        {  _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
        public void Apagar(int id)
        {
            ContatoModel contatoDB = GetById(id);
            if (contatoDB == null) throw new Exception("Houve um erro ao apagar o contato, o contato informado não foi localizado.");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
        }

        public ContatoModel Alterar(ContatoModel contato)
        {
            ContatoModel contatoDB = GetById(contato.Id);
            if (contatoDB == null) throw new Exception("Houve um erro na atualização do contato.");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }

        public List<ContatoModel> GetAllContacts(int userId)
        {
            return _bancoContext.Contatos.Where(x => x.UsuarioId == userId).ToList();

            
        }

        public ContatoModel GetById(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
    }
}
