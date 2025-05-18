using System.ComponentModel.DataAnnotations;
using WebAppMVC.Enums;

namespace WebAppMVC.Models
{
    public class UsuarioModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do usuário")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o Email do usuário")]
        [EmailAddress(ErrorMessage ="Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o Login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o Perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Digite a Senha do usuário")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public bool IsEdit { get; private set; }
        public void IsEdicao()
        {
            IsEdit = true;
        }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
