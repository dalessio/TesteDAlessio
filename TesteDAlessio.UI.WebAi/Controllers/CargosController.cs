using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteDAlessio.Domain.Entities;
using TesteDAlessio.Domain.Repository;

namespace TesteDAlessio.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        ICargoRepository repository;

        public CargosController(ICargoRepository cargoRepository)
        {
            repository = cargoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargos()
        {
          if (repository == null)
          {
              return NotFound();
          }

            var lista = await repository.GetAll();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetCargo(int id)
        {
          if (repository == null)
          {
              return NotFound();
          }
            var cargo = await repository.GetById(id);

            if (cargo == null)
            {
                return NotFound();
            }

            return cargo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargo(int id, Cargo cargo)
        {
            if (id != cargo.Id)
            {
                return BadRequest();
            }

            try
            {
                await repository.Add(cargo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CargoExists(id))
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
        public async Task<ActionResult<Cargo>> PostCargo(Cargo cargo)
        {
          if (repository == null)
          {
              return Problem("Entity set 'TesteDAlessioDbContext.Cargos'  is null.");
          }
            
            await repository.Add(cargo);

            return CreatedAtAction("GetCargo", new { id = cargo.Id }, cargo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            if (repository == null)
            {
                return NotFound();
            }
            var cargo = await repository.GetById(id);
            if (cargo == null)
            {
                return NotFound();
            }
           
            await repository.Remove(cargo);

            return NoContent();
        }
           private async Task<bool> CargoExists(int id)
        {
            var lista = await repository.GetAll();

            return (lista.Any(e => e.Id == id));
        }
    }
}
