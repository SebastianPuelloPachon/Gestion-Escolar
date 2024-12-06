using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEscolarAPI.Core.Entidades
{
    public class Profesor
    {
        public int ID { get; set; }
        public string NombreCompleto { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        // Relación uno a muchos con Asignaturas
        public ICollection<Asignatura> Asignaturas { get; set; }
    }
}
