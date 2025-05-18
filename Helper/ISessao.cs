using WebAppMVC.Models;

namespace WebAppMVC.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUser(UsuarioModel usuario);

        void RemoverSessaoDoUser();

        UsuarioModel GetSessaoUsuario();
      
    }
}
