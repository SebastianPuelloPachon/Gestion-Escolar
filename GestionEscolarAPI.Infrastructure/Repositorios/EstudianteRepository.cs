using GestionEscolarAPI.Core.Entidades;
using GestionEscolarAPI.Core.Interfaces;
using GestionEscolarAPI.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEscolarAPI.Infrastructure.Repositorios
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly ApplicationDbContext _context;

        public EstudianteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudiante>> GetAllAsync()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        public async Task<Estudiante> GetByIdAsync(int id)
        {
            return await _context.Estudiantes.FindAsync(id);
        }

        public async Task AddAsync(Estudiante estudiante)
        {
            await _context.Estudiantes.AddAsync(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Estudiante estudiante)
        {
            _context.Estudiantes.Update(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Estudiante estudiante)
        {
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
        }
    }
}
