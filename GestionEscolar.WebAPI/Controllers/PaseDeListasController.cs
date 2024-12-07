using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEscolarAPI.Core.Entidades.Agrupaciones;
using GestionEscolarAPI.Infrastructure.DBContext;

namespace GestionEscolar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaseDeListasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaseDeListasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PaseDeListas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaseDeLista>>> GetPaseDeLista()
        {
            return await _context.PaseDeLista.ToListAsync();
        }

        // GET: api/PaseDeListas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaseDeLista>> GetPaseDeLista(int id)
        {
            var paseDeLista = await _context.PaseDeLista.FindAsync(id);

            if (paseDeLista == null)
            {
                return NotFound();
            }

            return paseDeLista;
        }

        // PUT: api/PaseDeListas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaseDeLista(int id, PaseDeLista paseDeLista)
        {
            if (id != paseDeLista.ID)
            {
                return BadRequest();
            }

            _context.Entry(paseDeLista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaseDeListaExists(id))
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

        // POST: api/PaseDeListas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaseDeLista>> PostPaseDeLista(PaseDeLista paseDeLista)
        {
            _context.PaseDeLista.Add(paseDeLista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaseDeLista", new { id = paseDeLista.ID }, paseDeLista);
        }

        // DELETE: api/PaseDeListas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaseDeLista(int id)
        {
            var paseDeLista = await _context.PaseDeLista.FindAsync(id);
            if (paseDeLista == null)
            {
                return NotFound();
            }

            _context.PaseDeLista.Remove(paseDeLista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaseDeListaExists(int id)
        {
            return _context.PaseDeLista.Any(e => e.ID == id);
        }
    }
}
