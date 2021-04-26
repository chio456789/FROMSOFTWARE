using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.View_model
{
    class PerfilUser
    {
        public static IList Listar()
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = (from us in db.usuario select new {
                    Nombre = us.empleado.nombreEmp,
                    Apellido = us.empleado.apellidoPtEmp,
                    CI = us.empleado.ciEmpleado,
                    Direccion = us.empleado.direccionEmp,
                    Correo = us.empleado.correoEmp,
                    Cargo = us.empleado.cargoLaboral.nombreCg
                }
                );

                return query.ToList();


            }
        }
    }
}

