using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador2024.Entidades
{
    public class ClienteEmpresa : Cliente
    {

        public ClienteEmpresa() { }
        public ClienteEmpresa(string pNombre, string pContacto, string pCuit, string pEmail,
            string pTelefono, string pDireccion, string pFotoJpg) {
            this.Nombre = pNombre;
            this.CUIT = pCuit;
            this.Contacto = pContacto;
            this.Email = pEmail;
            this.Telefono = pTelefono;
            this.Direccion = pDireccion;
            this.FotoJpg = pFotoJpg;
        }

        public string? Contacto { get; set; }
        public string? FotoJpg { get; set; }
    }
}
