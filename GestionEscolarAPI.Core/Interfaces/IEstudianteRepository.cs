using GestionEscolarAPI.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEscolarAPI.Core.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<Estudiante>> GetAllAsync();
        Task<Estudiante> GetByIdAsync(int id);
        Task AddAsync(Estudiante estudiante);
        Task UpdateAsync(Estudiante estudiante);
        Task DeleteAsync(Estudiante estudiante);
    }
}
