using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;


namespace WpfApp1.View_model
{
    public class Items
    {
        public int? CodProd { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Decimal? Precio { get; set; }
        public string Imagen { get; set; } 
        public static IList Listar()
        {

       

            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = (from prod in db.productos
                             select new
                             {
                                 Nombre = prod.nombreProd,
                                 Descripcion = prod.descripcionProd,
                                 Precio = prod.precioProd,
                                 Imagen = prod.imagenProd
                                
                             }

                       //


                       /*from us in db.usuario
                                join emp in db.empleado on us.ciEmpleadoFK equals emp.ciEmpleado
                                join cargo in db.cargoLaboral on emp.codCargoFK equals cargo.codCargo
                                select new
                                {
                                    Nombre = emp.nombreEmp,
                                    Apellido = emp.apellidoPtEmp,
                                    CI = emp.ciEmpleado,
                                    Direccion = emp.direccionEmp,
                                    Correo = emp.correoEmp,
                                    Cargo = cargo.nombreCg,


                                }*/
                       );

                return query.ToList();


            }

        }
    }



    internal class categorias : DbSet<Model.categorias>
    {

    }
}
