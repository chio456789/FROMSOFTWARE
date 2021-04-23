using System;
using System.Collections;
using System.Collections.Generic;
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
                var query = (from pd in db.productos
                             join op in db.ordenProductos on pd.codProducto equals op.codProductoFK
                             join ct in db.categorias on pd.codCategoriaFK equals ct.codCategoria

                             select new
                             {
                                 Producto = pd.nombreProd,
                                 UnidadesVendidas = db.ordenProductos.Sum(op => op.cantidad),
                                 Categoria = ct.codCategoria,
                                 Costo = db.productos.Sum(pd => pd.costoProd),
                                 Precio = db.productos.Sum(pd => pd.precioProd),
                                 Total = (db.productos.Sum(pd => pd.precioProd)) - (db.productos.Sum(pd => pd.costoProd)),
                             });


                /*
                 db.CATEGORies.GroupBy(c => c.CATNAME).
                  Select(g => new 
                    {
                        g.Key, 
                        SUM = g.Sum(s => s.Inqueries.Select(t=>t.TotalTimeSpent).Sum())
                    });
                 */
                return query.ToList();
            }
        }
    }
}
