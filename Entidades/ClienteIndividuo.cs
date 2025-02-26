using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador2024.Entidades
{
    public class ClienteIndividuo : Cliente
    {
        public string? Apellido { get; set; }
        public string? Fotojpg {  get; set; }
        public ClienteIndividuo() { }
        public ClienteIndividuo(string pNombre, string pApellido,string pCuit, string pEmail,
            string pTelefono, string pDireccion, string pfotoJpg) {

            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.CUIT = pCuit;
            this.Email = pEmail;
            this.Telefono = pTelefono;
            this.Direccion = pDireccion;
            this.Fotojpg = pfotoJpg;

        }
    }
}
