using System.Collections.Generic;
using UsuarioCadastro.Models;

namespace UsuarioCadastro.Data.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);

        void Atualizar(string id, Usuario usuarioAtualizado);

        IEnumerable<Usuario> Buscar();

        Usuario Buscar(string id);

        Usuario BuscarPeloEmail(string email);

        void Remover(string id);
   
    }
}
