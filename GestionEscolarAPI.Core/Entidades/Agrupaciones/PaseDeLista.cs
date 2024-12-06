using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEscolarAPI.Core.Entidades.Agrupaciones
{
    public class PaseDeLista
    {
        public int ID { get; set; }
        public int CodigoEstudiante { get; set; }
        public Estudiante Estudiante { get; set; }

        public int CodigoAsignatura { get; set; }
        public Asignatura Asignatura { get; set; }

        public bool Asistencia { get; set; }
        public DateTime Fecha { get; set; }
    }
}
