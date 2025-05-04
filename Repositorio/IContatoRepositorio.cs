using WebAppMVC.Models;

namespace WebAppMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);
        List<ContatoModel> GetAllContacts();
    }
}
