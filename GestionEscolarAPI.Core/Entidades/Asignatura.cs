using GestionEscolarAPI.Core.Entidades.Agrupaciones.GestionEscolarAPI.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEscolarAPI.Core.Entidades
{
    public class Asignatura
    {
        public int CodigoAsignatura { get; set; }
        public string Nombre { get; set; }

        // Relación con Profesor
        public int ProfesorID { get; set; }
        public Profesor Profesor { get; set; }

        // Relación muchos a muchos con Estudiantes
        public ICollection<EstudianteAsignatura> EstudianteAsignaturas { get; set; }
    }
}
