using GestionDePersonas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDePersonas.DA
{
   public class ContextoBaseDeDatos : DbContext
    {
        public DbSet<Persona> Persona { get; set; } 

        public ContextoBaseDeDatos(DbContextOptions<ContextoBaseDeDatos> opciones) : base(opciones)
        {

        }
        
    }
}
