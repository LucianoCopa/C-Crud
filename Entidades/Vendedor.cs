using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador2024.Entidades
{
    public class Vendedor
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? DNI {  get; set; }
        public string? CUIL { get; set; }
        public string? FotojpgVendedor { get; set; }

        public Vendedor() { }
        public Vendedor(string pNombreV, string pApellidoV, string pDniV, string pCuilV ,string pFotoJpgV) {

        this.Nombre = pNombreV;
        this.Apellido = pApellidoV;
        this.DNI = pDniV;
            this.CUIL = pCuilV;
            this.FotojpgVendedor = pFotoJpgV;
        }
    }
}
