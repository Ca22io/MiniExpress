using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniExpress.Data;
using MiniExpress.Models;

namespace MiniExpress.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly BdContext _context;
        public UsuarioController(BdContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ObterUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (usuario.IdUsuario > 0 && UsuarioExiste(usuario.IdUsuario))
                {
                    _context.Update(usuario);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return Ok("Usuario atualizado com sucesso!");
                    }
                    else
                    {
                        return BadRequest("Erro ao atualizar o usuário.");
                    }
                }
                else
                {
                    var VerificarPerfil = usuario.IdPerfil == null ? 1 : usuario.IdPerfil; // Se não for informado, assume o perfil padrão

                    usuario.IdPerfil = VerificarPerfil;

                    usuario.DataCadastro = DateTime.Now; // Define a data de cadastro como a data atual

                    _context.Usuarios.Add(usuario);
                   if (await _context.SaveChangesAsync() > 0)
                   {
                       return Ok("Usuario criado com sucesso!");
                   }
                   else
                   {
                       return BadRequest("Erro ao criar o usuário.");
                   }
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirUsuario(int id)
        {
            if (UsuarioExiste(id))
            {
                var usuario = await _context.Usuarios.FindAsync(id);

                _context.Usuarios.Remove(usuario);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok("Usuário excluído com sucesso!");
                }
                else
                {
                    return BadRequest("Erro ao excluir o usuário.");
                }
            }
            else
            {
                return NotFound("Usuário não encontrado.");
            }
        }

        private bool UsuarioExiste(int id)
        {
            return _context.Usuarios.Any(x => x.IdUsuario == id);
        }

    }
}