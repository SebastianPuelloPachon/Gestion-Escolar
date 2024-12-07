using GestionEscolarAPI.Core.Entidades.Agrupaciones.GestionEscolarAPI.Core.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEscolarAPI.Core.Entidades
{
    public class Estudiante
    {
        [Key]
        public int CodigoEstudiante { get; set; }
        public string Nombre { get; set; }

        // Relación muchos a muchos con Asignaturas
        public ICollection<EstudianteAsignatura> EstudianteAsignaturas { get; set; }
    }
}
