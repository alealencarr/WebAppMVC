using WebAppMVC.Enums;

namespace WebAppMVC.Models
{
    public class UsuarioModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }             
        
        public string Login { get; set; }

        public PerfilEnum Perfil { get; set; }

        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }
    }
}
