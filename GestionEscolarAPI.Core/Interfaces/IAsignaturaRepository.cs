using GestionEscolarAPI.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEscolarAPI.Core.Interfaces
{
    public interface IAsignaturaRepository
    {
        Task<IEnumerable<Asignatura>> GetAllAsync();
        Task<Asignatura> GetByIdAsync(int id);
        Task AddAsync(Asignatura asignatura);
        Task UpdateAsync(Asignatura asignatura);
        Task DeleteAsync(Asignatura asignatura);
    }
}
