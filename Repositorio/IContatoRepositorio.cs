using WebAppMVC.Models;

namespace WebAppMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);
        void Apagar(int id);

        ContatoModel Alterar(ContatoModel contato);
        List<ContatoModel> GetAllContacts(int userId);

        ContatoModel GetById(int id);
    }
}
