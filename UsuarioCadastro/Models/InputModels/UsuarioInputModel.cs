
using System.ComponentModel.DataAnnotations;

namespace UsuarioCadastro.Models.InputModels
{
    public class UsuarioInputModel
    {
        [Required(ErrorMessage = "O Campo Nome é Obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo Email é Obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo Senha é Obrigatorio")]
        public string Senha { get; set; }
    }
}
