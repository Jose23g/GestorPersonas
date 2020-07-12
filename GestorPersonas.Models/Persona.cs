using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionDePersonas.Models
{
    public class Persona
    {

        [DisplayName("Identificación")]
        [Required(ErrorMessage = "La identificación es requerida")]
        [MaxLength(9, ErrorMessage = "El tamaño máximo de la identificación es de 9 caracteres")]
        public string Identificacion { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(20, ErrorMessage = "El tamaño máximo del Nombre es de 20 caracteres")]
        public string Nombre { get; set; }

        [DisplayName("Primer Apellido")]
        [Required(ErrorMessage = "El Apellido es requerido")]
        public string PrimerApellido { get; set; }

        [DisplayName("Segundo Apellido")]
        [Required(ErrorMessage = "El Apellido es requerido")]
        public string SegundoApellido { get; set; }
    }
}
