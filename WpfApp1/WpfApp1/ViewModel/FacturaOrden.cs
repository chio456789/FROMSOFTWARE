using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class FacturaOrden
    {
        puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities();
        public bool guardarFactura(TotalFactura tf)
        {
            try
            {
                factura f = new factura();
                f.codOrdenFK = tf.UltimoReg;
                f.totalFactura = tf.TotalFac;
                this.db.factura.Add(f);
                this.db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

    }
}
