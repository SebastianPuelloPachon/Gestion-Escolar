using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEscolarAPI.Core.Entidades.Agrupaciones
{
    namespace GestionEscolarAPI.Core.Entidades
    {
        public class EstudianteAsignatura
        {
            public int CodigoEstudiante { get; set; }
            public Estudiante Estudiante { get; set; }

            public int CodigoAsignatura { get; set; }
            public Asignatura Asignatura { get; set; }

            public decimal? Calificacion { get; set; }
        }
    }

}
