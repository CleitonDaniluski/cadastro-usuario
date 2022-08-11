using Microsoft.AspNetCore.Mvc;
using UsuarioCadastro.Data.Repositories;
using UsuarioCadastro.Models.InputModels;
using UsuarioCadastro.Models;
using UsuarioCadastro.Util;
using Microsoft.AspNetCore.Authorization;

namespace UsuarioCadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
       
        public UsuarioController(IUsuarioRepository interfaceUsuario)
        {
            _usuarioRepository = interfaceUsuario;
        }

        // GET: api/listausuario
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var usuario = _usuarioRepository.Buscar();
            return Ok(usuario);
        }


        // GET: api/usuario/{id}
        [HttpGet("{id}")]
        public IActionResult Get (string id)
        {
            var usuario = _usuarioRepository.Buscar(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // POST: api/usuario
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioInputModel usuarioNovo)
        {
            var usuario = new Usuario(usuarioNovo.Nome, usuarioNovo.Email, usuarioNovo.Senha);

            _usuarioRepository.Adicionar(usuario);

            return Created("", usuarioNovo);

        }

        // PUT: api/pokemon/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] UsuarioInputModel usuarioAtualizado)
        {
            var usuarioExistente = _usuarioRepository.Buscar(id);

            if (usuarioExistente == null)
                return NotFound();

            usuarioExistente.AtualizarUsuario(usuarioAtualizado.Nome, usuarioAtualizado.Email, usuarioAtualizado.Senha);

            _usuarioRepository.Atualizar(id, usuarioExistente);

            return Ok(usuarioExistente);
        }

        // DELETE api/usuario/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var usuario = _usuarioRepository.Buscar(id);

            if (usuario == null)
                return NotFound();

            _usuarioRepository.Remover(id);

            return NoContent();
        }

        // POST: api/usuario
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginInputModel loginModel)
        {
            var usuario = _usuarioRepository.BuscarPeloEmail(loginModel.Email);
            if(usuario == default) return NoContent();

            var checkPasswordResult = usuario.VerifyPassword(loginModel.Senha);

            if(checkPasswordResult) {
                var token = JwtAuth.GenerateToken(usuario);
                return Ok(new {
                    Token = token,
                    Usuario = usuario
                });
            };
            
            return BadRequest("Senha Incorreta!");
        }
    }
}