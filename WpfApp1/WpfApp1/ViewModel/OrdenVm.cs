using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    public class OrdenVm
    {

        public int? N { get; set; }
        public int? cantidad { get; set; }

        public string descripcion { get; set; }
        public Decimal? precioUnitario { get; set; }
        

        public Decimal? subtotal { get; set; }
        public OrdenVm(int? cont, int? cantidad, decimal? precioUnitario, string descripcion)
        {
            this.N = cont;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            this.precioUnitario = precioUnitario;
            
            this.subtotal = this.cantidad*this.precioUnitario;
        }

        public OrdenVm()
        {
            this.descripcion = string.Empty;
        }

        public OrdenVm(int? cont)
        {
            this.N = cont;
        }

        public decimal? subtotalItem(int? cantidad, decimal? precioUnitario)
        {
            decimal? a = cantidad * precioUnitario;
            return a;
        }

        
    }
}
