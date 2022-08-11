
using System.ComponentModel.DataAnnotations;

namespace UsuarioCadastro.Models.InputModels
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "O Campo Email é Obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo Senha é Obrigatorio")]
        public string Senha { get; set; }
    }
}
