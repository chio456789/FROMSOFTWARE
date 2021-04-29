using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public Decimal? borrarFila(int id, ObservableCollection<OrdenVm> listaOr)
        {
            int con = 0;
            int aux = 0;
            Decimal? precio = 0;
            int? cant = 0;
            foreach (var l in listaOr)
            {

                if (l.N == id)
                {
                    aux = con;
                    cant = l.cantidad;
                    precio = l.precioUnitario;
                }
                con++;

            }
            listaOr.RemoveAt(aux);
            return cant * precio;
        }

    }
}
