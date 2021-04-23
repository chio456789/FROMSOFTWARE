using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class Usuario_emp
    {

        puntoDeVentaDB_testEntities bd = new puntoDeVentaDB_testEntities();

        /*--------------Usuario------------*/
        public bool CreateUser(Usuarios us)
        {
            try
            {
                usuario us1 = new usuario();
                us1.nombreUs = us.NombreUser;
                us1.passwordUs = us.Contrasena;
                us1.ciEmpleadoFK= us.Emp2.Ci;
                this.bd.usuario.Add(us1);
                this.bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public bool DeleteUser(string d)
        {
            try
            {
                usuario us3 = this.bd.usuario.Where(s => s.ciEmpleadoFK == d).FirstOrDefault<usuario>(); ;
               
                this.bd.usuario.Remove(us3);
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool UpdateUser(Usuarios us3)
        {
            try
            {

                usuario us4 = this.bd.usuario.Where(x=>x.ciEmpleadoFK==us3.Emp2.Ci).First();
                us4.nombreUs = us3.NombreUser;
                us4.passwordUs = us3.Contrasena;
                this.bd.Entry(us4).State = System.Data.Entity.EntityState.Modified;
                this.bd.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        /*------------------------------------Empleado------------------------------------------------------*/
        public bool CreateEmpleado(Empleado emp1)
        {
            try
            {
                empleado emp2 = new empleado();
                emp2.nombreEmp = emp1.Nombre;
                emp2.apellidoPtEmp = emp1.ApellidoPaterno;
                emp2.ciEmpleado = emp1.Ci;
                emp2.direccionEmp = emp1.Direccion;
                emp2.correoEmp = emp1.Correo;
                emp2.codCargoFK = emp1.Cargo.CodCargo;
                this.bd.empleado.Add(emp2);
                this.bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool DeleteEmpleado(string d)
        {
            try
            {
                empleado emp3 = this.bd.empleado.Find(d);
                this.bd.empleado.Remove(emp3);
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool UpdateEmpleado(Empleado emp3)
        {
            try
            {

                empleado emp4 = this.bd.empleado.Find(emp3.Ci);
                emp4.nombreEmp = emp3.Nombre;
                emp4.apellidoPtEmp = emp3.ApellidoPaterno;
                this.bd.Entry(emp4).State = System.Data.Entity.EntityState.Modified;
                this.bd.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }

        public List<Cargo> listar_cargos()
        {
            return (from hh in this.bd.cargoLaboral select new Cargo()
            {
                CodCargo= hh.codCargo,
                NombreCargo= hh.nombreCg
                
            }).ToList();
        }

    }
}