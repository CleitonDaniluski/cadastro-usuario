
using System.ComponentModel.DataAnnotations;

namespace UsuarioCadastro.Models.InputModels
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "O Campo Email ? Obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo Senha ? Obrigatorio")]
        public string Senha { get; set; }
    }
}
