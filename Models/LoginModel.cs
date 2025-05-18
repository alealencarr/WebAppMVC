using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe o Login continuar.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a Senha para continuar.")]
        public string Senha { get; set; }
    }
}
