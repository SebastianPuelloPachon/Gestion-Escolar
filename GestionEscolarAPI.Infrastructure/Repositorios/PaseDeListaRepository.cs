using GestionEscolarAPI.Core.Entidades.Agrupaciones;
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
    public class PaseDeListaRepository : IPaseDeListaRepository
    {
        private readonly ApplicationDbContext _context;

        public PaseDeListaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaseDeLista>> GetAllAsync()
        {
            return await _context.PaseDeLista.ToListAsync();
        }

        public async Task<PaseDeLista> GetByIdAsync(int id)
        {
            return await _context.PaseDeLista.FindAsync(id);
        }

        public async Task AddAsync(PaseDeLista paseDeLista)
        {
            await _context.PaseDeLista.AddAsync(paseDeLista);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PaseDeLista paseDeLista)
        {
            _context.PaseDeLista.Update(paseDeLista);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PaseDeLista paseDeLista)
        {
            _context.PaseDeLista.Remove(paseDeLista);
            await _context.SaveChangesAsync();
        }
    }
}
