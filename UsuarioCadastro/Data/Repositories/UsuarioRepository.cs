using UsuarioCadastro.Data.Configurations;
using UsuarioCadastro.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace UsuarioCadastro.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuario;

        public UsuarioRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _usuario = database.GetCollection<Usuario>("usuario");
        }

        public void Adicionar (Usuario usuario)
        {
            _usuario.InsertOne(usuario);
        }


        public void Atualizar(string id, Usuario usuarioAtualizado)
        {
            _usuario.ReplaceOne(usuario => usuario.Id == id, usuarioAtualizado);
        }

        public IEnumerable<Usuario> Buscar()
        {
            return _usuario.Find(usuario => true).ToList();
        }

        public Usuario Buscar(string id)
        {
            return _usuario.Find(Usuario => Usuario.Id == id).FirstOrDefault();
        }

        public Usuario BuscarPeloEmail(string email)
        {
            return _usuario.Find(Usuario => Usuario.Email == email).FirstOrDefault();
        }

        public void Remover(string id)
        {
            _usuario.DeleteOne(usuario => usuario.Id == id);
        }


    }
}
