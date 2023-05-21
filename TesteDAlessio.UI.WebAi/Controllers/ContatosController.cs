using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteDAlessio.Domain.Entities;
using TesteDAlessio.Domain.Repository;

namespace TesteDAlessio.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        IContatoRepository repository;

        public ContatosController(IContatoRepository contatoRepository)
        {
            repository = contatoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> GetListarContatos()
        {
          if (repository == null)
          {
              return NotFound();
          }

            var lista = await repository.GetAll();

          return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> GetContatoPorId(int id)
        {
          if (repository == null)
          {
              return NotFound();
          }
            var contato = await repository.GetById(id);

            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddContato(int id, Contato contato)
        {
            if (id != contato.Id)
            {
                return BadRequest();
            }

            try
            {
                await repository.Add(contato);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await ContatoExists(id))
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
        public async Task<ActionResult<Contato>> PostAddContato(Contato contato)
        {
          if (repository == null)
          {
              return Problem("Entity set 'TesteDAlessioDbContext.Contatos'  is null.");
          }

            await repository.Add(contato);

            return CreatedAtAction("GetContato", new { id = contato.Id }, contato);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContato(int id)
        {
            if (repository == null)
            {
                return NotFound();
            }
            var contato = await repository.GetById(id);
            if (contato == null)
            {
                return NotFound();
            }

            
            await repository.Remove(contato);

            return NoContent();
        }

        private async Task<bool> ContatoExists(int id)
        {
            var contatos = await repository.GetAll();

            return (contatos.Any(e => e.Id == id));
        }
    }
}
