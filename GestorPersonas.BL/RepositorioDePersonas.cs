using GestionDePersonas.DA;
using GestionDePersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionDePersonas.BL
{
    public class RepositorioDePersonas : IRepositorioDePersonas
    {

        private ContextoBaseDeDatos ElContextoDeBaseDeDatos;
        public RepositorioDePersonas(ContextoBaseDeDatos contexto)
        {
            ElContextoDeBaseDeDatos = contexto;
        }
        public void Agregar(Persona personas)
        {
            ElContextoDeBaseDeDatos.Persona.Add(personas);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public Persona DetallePersona(int id)
        {
            Persona persona = ElContextoDeBaseDeDatos.Persona.Find(id);
            return persona;
        }

        public List<Persona> ListaDePersonas()
        {
            List<Persona> laListadePersonas;
            laListadePersonas = ElContextoDeBaseDeDatos.Persona.ToList();
            return laListadePersonas;

        }
    }

}
