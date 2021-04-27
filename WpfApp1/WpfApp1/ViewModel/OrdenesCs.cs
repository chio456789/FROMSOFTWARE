using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class OrdenesCs
    {
        public static IList ListarOrden()
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = (from or in db.orden
                             select new
                             {
                                 CodOrden = or.codOrden,
                                 ApCliente = or.clientes.apellidoCliente,
                                 Productos = or.ordenProductos,
                                 Observ = or.observaciones,
                                 Estado = or.estadoOrden
                             }
                );

                return query.ToList();


            }
        }

        public bool EstadoDeLaOrden(string ord)
        {
            return true;
        }
    }
}
