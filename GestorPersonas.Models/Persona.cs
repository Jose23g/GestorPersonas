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
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [MaxLength(9 , ErrorMessage = "El tamaño máximo de la identificación es de 9 caracteres")]
        [MinLength(9 , ErrorMessage = "El tamaño mínimo de la identificación es de 9 caracteres")]
        public string Identificacion { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(20, ErrorMessage = "El tamaño máximo del Nombre es de 20 caracteres")]
        [RegularExpression("^([a-zA-ZñÑáéíóúÁÉÍÓÚ_-])+((\\s*)+([a-zA-ZñÑáéíóúÁÉÍÓÚ_-]*)*)+$", ErrorMessage = "Solo se permiten letras")]
        public string Nombre { get; set; }

        [DisplayName("Primer Apellido")]
        [RegularExpression("^([a-zA-ZñÑáéíóúÁÉÍÓÚ_-])+((\\s*)+([a-zA-ZñÑáéíóúÁÉÍÓÚ_-]*)*)+$", ErrorMessage = "Solo se permiten letras")]
        [Required(ErrorMessage = "El primer apellido es requerido")]
        public string Primer_Apellido { get; set; }

        [DisplayName("Segundo Apellido")]
        [RegularExpression("^([a-zA-ZñÑáéíóúÁÉÍÓÚ_-])+((\\s*)+([a-zA-ZñÑáéíóúÁÉÍÓÚ_-]*)*)+$", ErrorMessage = "Solo se permiten letras")]
        [Required(ErrorMessage = "El segundo apellido es requerido")]
        public string Segundo_Apellido { get; set; }

     
        [DisplayName("Foto")]
        [Required(ErrorMessage = "La Foto es requerida")]
        public Byte[] Foto { get; set; }



    }
}
