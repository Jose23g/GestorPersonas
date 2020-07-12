using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace GestionDePersonas.Models
{
    public class Persona
    {

        public int Id { get; set; }

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
        public string Primer_Apellido { get; set; }

        [DisplayName("Segundo Apellido")]
        [Required(ErrorMessage = "El Apellido es requerido")]
        public string Segundo_Apellido { get; set; }

        [NotMapped]
        [DisplayName("Foto")]
        [Required(ErrorMessage = "La foto es requerida")]
        public Byte?[] Foto { get; set; }

        [NotMapped]
        [DisplayName("Imagen")]
        [Required(ErrorMessage = "La foto es requerida")]
        public IFormFile Imagen { get; set; }

    }
}
