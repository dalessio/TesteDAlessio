using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteDAlessio.Domain.Entities;
using TesteDAlessio.Infrastructure.DBContext;
using TesteDAlessio.UI.WebApp.Models;

namespace TesteDAlessio.UI.WebApp.Controllers
{
    public class ContatosController : Controller
    {
        private readonly TesteDAlessioDbContext _context;

        public ContatosController(TesteDAlessioDbContext context)
        {
            _context = context;
        }

        // GET: Contatos
        public async Task<IActionResult> Index()
        {
              return _context.Contatos != null ? 
                          View(await _context.Contatos.ToListAsync()) :
                          Problem("Entity set 'TesteDAlessioDbContext.Contatos'  is null.");
        }

        // GET: Contatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // GET: Contatos/Create
        public async Task<IActionResult> Create()
        {
            var model = new ContatoModel();

            var cargos = await _context.Cargos.ToListAsync();

            model.Cargos = cargos.Select(c => new CargoModel {Id = c.Id, Ativo = c.Ativo, DataCriacao = c.DataCriacao, Descricao = c.Descricao }).ToList();

            return View(model);
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Telefone,Email,DataNascimento,Sexo,Id,CargoId,Ativo")] ContatoModel contatoModel)
        {
            if (ModelState.IsValid)
            {
                contatoModel.DataCriacao = DateTime.Now;

                Contato contato = ModelToEntity(contatoModel);

                _context.Add(contato);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(contatoModel);
        }

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {



            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }
            
            var contato = await _context.Contatos.FindAsync(id);

            if (contato == null)
            {
                return NotFound();
            }

            var model = EntityToModel(contato);
          
            var cargos = await _context.Cargos.ToListAsync();

            if (cargos == null)
            {
                return NotFound();
            }

            model.Cargos = cargos.Select(c => new CargoModel { Id = c.Id, Ativo = c.Ativo, DataCriacao = c.DataCriacao, Descricao = c.Descricao }).ToList();

            return View(model);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Telefone,Email,DataNascimento,Sexo,Id,CargoId,Ativo")] ContatoModel contatoModel)
        {
            if (id != contatoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Contato contato = ModelToEntity(contatoModel);

                try
                {
                    _context.Update(contato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(contato.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contatoModel);
        }

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contatos == null)
            {
                return Problem("Entity set 'TesteDAlessioDbContext.Contatos'  is null.");
            }
            var contato = await _context.Contatos.FindAsync(id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(int id)
        {
          return (_context.Contatos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private Contato ModelToEntity(ContatoModel contatoModel)
        {
            var contato = new Contato();

            contato.Id = contatoModel.Id;

            if(contatoModel.DataCriacao.HasValue)
                contato.DataCriacao = contatoModel.DataCriacao.Value;

            contato.Nome = contatoModel.Nome;

            if (contatoModel.DataNascimento.HasValue)
                contato.DataNascimento = contatoModel.DataNascimento.Value;
            
            contato.Sexo = contatoModel.Sexo;

            contato.Email = contatoModel.Email;
            contato.Telefone = contatoModel.Telefone;

            contato.Ativo = contatoModel.Ativo;

            if(_context.Cargos != null )
                contato.Cargo = _context.Cargos.Find(contatoModel.CargoId);

            return contato;
        }

        private static ContatoModel EntityToModel(Contato contato)
        {
            var contatoModel = new ContatoModel();

            contatoModel.Id = contato.Id;
            contatoModel.DataCriacao = contato.DataCriacao;

            contatoModel.Nome = contato.Nome;
            contatoModel.DataNascimento = contato.DataNascimento;

            contatoModel.Sexo = contato.Sexo;

            contatoModel.Email = contato.Email;
            contatoModel.Telefone = contato.Telefone;

            if (contato.Cargo != null)
                contatoModel.CargoId = contato.Cargo.Id;

            contatoModel.Ativo = contato.Ativo;

            return contatoModel;
        }
    }
}
