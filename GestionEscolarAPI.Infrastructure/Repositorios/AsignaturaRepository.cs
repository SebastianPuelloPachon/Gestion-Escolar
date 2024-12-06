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
    public class AsignaturaRepository : IAsignaturaRepository
    {
        private readonly ApplicationDbContext _context;

        public AsignaturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asignatura>> GetAllAsync()
        {
            return await _context.Asignaturas.ToListAsync();
        }

        public async Task<Asignatura> GetByIdAsync(int id)
        {
            return await _context.Asignaturas.FindAsync(id);
        }

        public async Task AddAsync(Asignatura asignatura)
        {
            await _context.Asignaturas.AddAsync(asignatura);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Asignatura asignatura)
        {
            _context.Asignaturas.Update(asignatura);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Asignatura asignatura)
        {
            _context.Asignaturas.Remove(asignatura);
            await _context.SaveChangesAsync();
        }
    }
}
