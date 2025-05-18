using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Informe o Login continuar.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe o E-mail para continuar.")]
        public string Email { get; set; }
    }
}
