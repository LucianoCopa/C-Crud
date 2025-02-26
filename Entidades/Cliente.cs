using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador2024.Entidades
{
    public abstract class Cliente
    {
        public string? Nombre { get; set; }
        public string? CUIT { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        
        public Cliente() { }
        public Cliente(string pNombre, string pCuit, string pEmail,
            string pTelefono, string pDireccion)
        {
            this.Nombre = pNombre;
            this.CUIT = pCuit;
            this.Email = pEmail;
            this.Telefono = pTelefono;
            this.Direccion = pDireccion;
        }
    }

}
