using System.ComponentModel.DataAnnotations;

namespace UsuariosWeb.Presentation.Models
{
    public class AccountLoginModel
    {

        [Required(ErrorMessage = "Informe seu e-mail.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha.")]
        [MinLength(6, ErrorMessage = "Mínimo de {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Máximo de {1} caracteres.")]
        public string Senha { get; set; }

    }
}
