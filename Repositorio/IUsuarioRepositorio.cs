using WebAppMVC.Models;

namespace WebAppMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorEmailELogin(string email, string login);

        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel Adicionar(UsuarioModel Usuario);
        void Apagar(int id);

        UsuarioModel Alterar(UsuarioModel Usuario);
        List<UsuarioModel> GetAllUsers();

        UsuarioModel GetById(long id);
    }
}
