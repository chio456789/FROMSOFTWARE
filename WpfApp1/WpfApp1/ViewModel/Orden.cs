using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    public class Orden
    {
        public string nitClientes { get; set; }
        public bool estadoOrden { get; set; }
        public Decimal? precioUnitario { get; set; }
        public int? cantidad { get; set; }


    }
}
