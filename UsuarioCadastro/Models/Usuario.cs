namespace UsuarioCadastro.Models
{
    public class Usuario
    {

        public Usuario(string nome, string email, string senha)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Email = email;
            SetPassword(senha);

        }

        private void SetPassword(string senha)
        {
            Senha = BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public string Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public void AtualizarUsuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            SetPassword(senha);
        }

        public bool VerifyPassword(string newPassword)
        {
            return BCrypt.Net.BCrypt.Verify(newPassword, Senha);
        }

    }
}
