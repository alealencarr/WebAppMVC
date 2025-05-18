using WebAppMVC.Models;

namespace WebAppMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel Adicionar(UsuarioModel Usuario);
        void Apagar(int id);

        UsuarioModel Alterar(UsuarioModel Usuario);
        List<UsuarioModel> GetAllUsers();

        UsuarioModel GetById(long id);
    }
}
