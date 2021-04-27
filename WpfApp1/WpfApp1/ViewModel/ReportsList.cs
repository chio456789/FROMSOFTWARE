using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class ReportsList
    {
        public static IList listarProductos()
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.CP_reporteProducto();
 
                return query.ToList();
            }
        }

        /*public static IList masVendido()
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.CP_RepMasVendido();

                return query.ToList();
            }
        }

        public static IList menosVendido()
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.CP_RepMenosVendido();

                return query.ToList();
            }
        }

        public static IList mayorDiferencia()
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.CP_RepMayorDiferencia();

                return query.ToList();
            }
        }

        public static IList menorDiferencia()
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.CP_RepMenorDiferencia();

                return query.ToList();
            }
        }*/

        public static IList listarVentas()
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.cp_ReporteVentas();

                return query.ToList();
            }
        }

    }
}
