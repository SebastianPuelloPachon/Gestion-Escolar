using GestionEscolarAPI.Core.Entidades;
using GestionEscolarAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionEscolarAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturasController : ControllerBase
    {
        private readonly IAsignaturaRepository _asignaturaRepository;

        public AsignaturasController(IAsignaturaRepository asignaturaRepository)
        {
            _asignaturaRepository = asignaturaRepository;
        }

        // GET: api/asignaturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignatura>>> GetAsignaturas()
        {
            var asignaturas = await _asignaturaRepository.GetAllAsync();
            return Ok(asignaturas);
        }

        // GET: api/asignaturas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignatura>> GetAsignatura(int id)
        {
            var asignatura = await _asignaturaRepository.GetByIdAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }
            return Ok(asignatura);
        }

        // POST: api/asignaturas
        [HttpPost]
        public async Task<ActionResult<Asignatura>> CreateAsignatura(Asignatura asignatura)
        {
            await _asignaturaRepository.AddAsync(asignatura);
            return CreatedAtAction(nameof(GetAsignatura), new { id = asignatura.CodigoAsignatura }, asignatura);
        }

        // PUT: api/asignaturas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsignatura(int id, Asignatura asignatura)
        {
            if (id != asignatura.CodigoAsignatura)
            {
                return BadRequest();
            }

            await _asignaturaRepository.UpdateAsync(asignatura);
            return NoContent();
        }

        // DELETE: api/asignaturas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignatura(int id)
        {
            var asignatura = await _asignaturaRepository.GetByIdAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }

            await _asignaturaRepository.DeleteAsync(asignatura);
            return NoContent();
        }
    }
}
