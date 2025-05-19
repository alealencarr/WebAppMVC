using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class AlterarSenhaModel
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite a Senha Atual do usuário.")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Digite a nova senha do usuário.")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha do usuário.")]
        [Compare("NovaSenha", ErrorMessage = "A senha não confere com a nova Senha.")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
