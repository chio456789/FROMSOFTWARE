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
                var query = (from op in db.ordenProductos
                             select new
                             {
                                 Producto = op.productos.nombreProd,
                                 UnidadesVendidas = op.cantidad,
                                 Categoria = op.productos.categorias.nombreCtg,
                                 Costo = op.productos.costoProd,
                                 Precio = op.productos.precioProd,
                                 Total = (op.productos.precioProd) * (op.cantidad)
                             });


                //si funciona
                /*(from op in db.ordenProductos
                         select new
                         {
                             Producto = op.productos.nombreProd,
                             UnidadesVendidas = op.cantidad,
                             Categoria = op.productos.categorias.nombreCtg,
                             Costo = op.productos.costoProd,
                             Precio = op.productos.precioProd,
                             Total = (op.productos.precioProd) * (op.cantidad)
                         });*/


                //Si funciona
                //var query = db.productos
                //            .Join(
                //            db.ordenProductos,
                //            pd => pd.codProducto,
                //            op => op.codProductoFK,
                //            (pd, op) => new { pd.nombreProd, op.cantidad })
                //            .GroupBy(pd => pd.nombreProd)
                //            .Select(x => new { Producto = x.Key, UnidadesVendidas = x.Select(g => g.cantidad).Sum() });

                /*
                 var query = db.productos
                            .Join(
                            db.ordenProductos,
                            pd => pd.codProducto,
                            op => op.codProductoFK,
                            (pd, op) => new { pd.nombreProd, op.cantidad, pd.codCategoriaFK })
                            .Join(
                            db.categorias,
                            pd => pd.codCategoriaFK,
                            ct => ct.codCategoria,
                            (pd, ct) => new { ct.nombreCtg }
                            )
                            .GroupBy(y => y.nombreCtg)
                            .Select(x => new { Producto = x.Key, UnidadesVendidas = x.Select(g => g.cantidad).Sum() });
                 */
                return query.ToList();
            }
        }
    }
}
