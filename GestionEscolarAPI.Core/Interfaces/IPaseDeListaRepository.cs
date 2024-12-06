using GestionEscolarAPI.Core.Entidades.Agrupaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEscolarAPI.Core.Interfaces
{
    public interface IPaseDeListaRepository
    {
        Task<IEnumerable<PaseDeLista>> GetAllAsync();
        Task<PaseDeLista> GetByIdAsync(int id);
        Task AddAsync(PaseDeLista paseDeLista);
        Task UpdateAsync(PaseDeLista paseDeLista);
        Task DeleteAsync(PaseDeLista paseDeLista);
    }
}
