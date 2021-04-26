using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    public class OrdenVm
    {
        public int? cantidad { get; set; }

        public string descripcion { get; set; }
        public Decimal? precioUnitario { get; set; }
        

        public Decimal? subtotal { get; set; }

        public OrdenVm(int? cantidad, decimal? precioUnitario, string descripcion)
        {
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            this.precioUnitario = precioUnitario;
            
            this.subtotal = this.cantidad*this.precioUnitario;
        }

        public OrdenVm()
        {
            this.descripcion = string.Empty;
        }
    }
}
