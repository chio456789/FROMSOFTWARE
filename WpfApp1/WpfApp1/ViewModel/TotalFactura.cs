using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class TotalFactura
    {
        private decimal? totalFactura;
        private int? ultimoRegistro;

        public TotalFactura()
        {
            this.init();
        }
        private void init()
        {
            TotalFac = totalFactura;
            UltimoReg = ultimoRegistro;
        }
            public TotalFactura(decimal? _totalFactura)
        {
            this.totalFactura = _totalFactura;
        }

        public int? encontrarUltimaOrden()
        {
            try
            {

                using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
                {
                    int? v = db.orden.Max(d => d.codOrden);
                    return v;
                }   
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public decimal? TotalFac { get => totalFactura; set => totalFactura = value; }
        public int? UltimoReg { get => ultimoRegistro; set => ultimoRegistro = value; }
    }
}
