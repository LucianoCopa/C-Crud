using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador2024.Entidades
{
    public class Producto
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioCosto { get; set; }
        public double Margen { get; set; }
        public double IVA { get; set; }
        public decimal PrecioBruto { get { return this.PrecioCosto * Convert.ToDecimal(Margen); } }
        public decimal PrecioVenta { get { return this.PrecioBruto * Convert.ToDecimal(this.IVA); } }
        public string? Proveedor { get; set; }
        public string? Categoria { get; set; }
        public string? SubCategoria { get; set; }

        public string? Fotojpg {  get; set; }


        public Producto() { }
        public Producto( string pNombre, string pDescripcion, decimal pPrecioCosto
            , double pMargen, double pIVA
            , string pProveedor, string pCategoria, string pSubcategoria, string productoFotoJpg) 
        { 

            this.Nombre= pNombre;
            this.Descripcion = pDescripcion;
            this.PrecioCosto = pPrecioCosto;
            this.Margen = pMargen;
            this.IVA = pIVA;
            this.Proveedor = pProveedor;
            this.Categoria = pCategoria;
            this.SubCategoria = pSubcategoria;
            this.Fotojpg  = productoFotoJpg;
        }   
    }
}
