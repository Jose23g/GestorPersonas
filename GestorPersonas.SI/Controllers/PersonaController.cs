using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDePersonas.BL;
using GestionDePersonas.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionDePersonas.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IRepositorioDePersonas RepositorioDePersonas;


        public PersonaController(IRepositorioDePersonas repositorio)
        {
            RepositorioDePersonas = repositorio;
        }
        // GET: api/<PersonaController>
        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            List<Persona> laListaDePersonas;
            laListaDePersonas = RepositorioDePersonas.ListaDePersonas();
            return laListaDePersonas;
        }

        // POST api/<PersonaController>
        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            try
            {
                RepositorioDePersonas.Agregar(persona);

            }
            catch
            {
                return NotFound();
            }
            return Ok(persona);
        }


    }
}
