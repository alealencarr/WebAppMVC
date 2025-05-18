using Microsoft.EntityFrameworkCore;
using WebAppMVC.Data;
using WebAppMVC.Models;

namespace WebAppMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();

            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }
        public void Apagar(int id)
        {
            UsuarioModel UsuarioDB = GetById(id);
            if (UsuarioDB == null) throw new Exception("Houve um erro ao apagar o Usuario, o Usuario informado não foi localizado.");

            _bancoContext.Usuarios.Remove(UsuarioDB);
            _bancoContext.SaveChanges();
        }

        public UsuarioModel Alterar(UsuarioModel usuario)
        {
            UsuarioModel UsuarioDB = GetById(usuario.Id ?? (long)0);
            if (UsuarioDB == null) throw new Exception("Houve um erro na atualização do Usuario.");

            UsuarioDB.Name = usuario.Name;
            UsuarioDB.Email = usuario.Email;
            UsuarioDB.DataAlteracao = DateTime.Now;
            UsuarioDB.Login = usuario.Login;
            UsuarioDB.Perfil = usuario.Perfil;
            UsuarioDB.Senha = usuario.Senha;
 
            _bancoContext.Usuarios.Update(UsuarioDB);
            _bancoContext.SaveChanges();
            return UsuarioDB;
        }

        public List<UsuarioModel> GetAllUsers()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel GetById(long id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Email.ToUpper() == email.ToUpper());
        }
    }
}
