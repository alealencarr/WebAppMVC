using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class ContatoModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar o Nome do Contato.")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Favor informar o Email do Contato.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Favor informar o Celular do Contato.")]
        [Phone(ErrorMessage = "Telefone inválido.")]       
        public string Celular { get; set; } = string.Empty;

        public int UsuarioId { get; set; }     

        public UsuarioModel? Usuario { get; set; }
    }
}
