using GestionEscolarAPI.Core.Entidades;
using GestionEscolarAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionEscolarAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstudiantesController(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        // GET: api/estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            var estudiantes = await _estudianteRepository.GetAllAsync();
            return Ok(estudiantes);
        }

        // GET: api/estudiantes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var estudiante = await _estudianteRepository.GetByIdAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return Ok(estudiante);
        }

        // POST: api/estudiantes
        [HttpPost]
        public async Task<ActionResult<Estudiante>> CreateEstudiante(Estudiante estudiante)
        {
            await _estudianteRepository.AddAsync(estudiante);
            return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.CodigoEstudiante }, estudiante);
        }

        // PUT: api/estudiantes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstudiante(int id, Estudiante estudiante)
        {
            if (id != estudiante.CodigoEstudiante)
            {
                return BadRequest();
            }

            await _estudianteRepository.UpdateAsync(estudiante);
            return NoContent();
        }

        // DELETE: api/estudiantes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _estudianteRepository.GetByIdAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            await _estudianteRepository.DeleteAsync(estudiante);
            return NoContent();
        }
    }
}
