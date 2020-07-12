using GestionDePersonas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDePersonas.BL
{
    public interface IRepositorioDePersonas
    {
        List<Persona> ListaDePersonas();
        void Agregar(Persona personas);
        Persona DetallePersona(int id);
    }
}
