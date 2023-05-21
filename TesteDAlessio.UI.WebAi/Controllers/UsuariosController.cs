using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteDAlessio.Domain.Entities;
using TesteDAlessio.Domain.Repository;

namespace TesteDAlessio.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IUsuarioRepository repository;

        public UsuariosController(IUsuarioRepository UsuarioRepository)
        {
            repository = UsuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
          if (repository == null)
          {
              return NotFound();
          }

            var lista = await repository.GetAll();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
          if (repository == null)
          {
              return NotFound();
          }
            var Usuario = await repository.GetById(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario Usuario)
        {
            if (id != Usuario.Id)
            {
                return BadRequest();
            }

            try
            {
                await repository.Add(Usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario Usuario)
        {
          if (repository == null)
          {
              return Problem("Entity set 'TesteDAlessioDbContext.Usuarios'  is null.");
          }
            
            await repository.Add(Usuario);

            return CreatedAtAction("GetUsuario", new { id = Usuario.Id }, Usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (repository == null)
            {
                return NotFound();
            }
            var Usuario = await repository.GetById(id);
            if (Usuario == null)
            {
                return NotFound();
            }
           
            await repository.Remove(Usuario);

            return NoContent();
        }
           private async Task<bool> UsuarioExists(int id)
        {
            var lista = await repository.GetAll();

            return (lista.Any(e => e.Id == id));
        }
    }
}
