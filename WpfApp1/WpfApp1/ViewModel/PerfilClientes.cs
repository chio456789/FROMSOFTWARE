using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class PerfilClientes
    {


        public static IList ListarClientes()
        {

            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = (from cl in db.clientes
                             
                             select new
                             {
                                 nitCliente = cl.nitCliente,
                                 nombreCliente = cl.nombreCliente,
                                 apellidoCliente = cl.apellidoCliente
                             }
                       );

                return query.ToList();

            }
        }
    }
}
