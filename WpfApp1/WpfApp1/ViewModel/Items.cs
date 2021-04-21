using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.View_model
{
    class Items
    {
        //esta funcion permite visualizar la base de datos dentro del datagrid y actualiza los
        //datos cuando se eliminen actualicen y  borren
        // pobre chiyo
        // Lo volvió a cagar
        public List<PersonViewModel> Refresh()
        {
            List<PersonViewModel> lst = new List<PersonViewModel>();
            using (Model.puntoDeVentaDB_testEntities product = new Model.puntoDeVentaDB_testEntities())
            {
               lst = (from d in product.productos
                       select new PersonViewModel
                       {

                           /* 
                             * var query = (from us in db.usuario
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
                             */
                            
                           IDProduct = d.idProducto,
                           NombreProduct = d.nombreProd,
                           DescripcionProduct = d.descripcionProd,
                           PrecioProduct = (decimal)d.precioProd,
                           CostoProduct = (decimal)d.codProducto,
                           DisponibilidadProduct = (bool)d.disponibilidadProd
                       }).ToList();
            }

            return lst;
        }
        public void agregar(string nombre,string descripcion,decimal precio,decimal costo,bool disponibilidad)
        {
            //este metodo esta recibiendo los parametros de los textbox para poder almacenarlos en la base de datos

            using (Model.puntoDeVentaDB_testEntities agregar = new Model.puntoDeVentaDB_testEntities())
            {
                var Addproduct  =  new Model.productos();                                
                Addproduct.nombreProd = nombre;
                Addproduct.descripcionProd = descripcion;
                Addproduct.precioProd = precio;
                Addproduct.costoProd = costo;
                Addproduct.disponibilidadProd = disponibilidad;
                agregar.productos.Add(Addproduct);
                agregar.SaveChanges();
            }

           

            // es recomendable despues de que el metodo se haya ejecutado en el botton llamar otra vez al metodo Refresh()
        }
        public void Editar(int ID, string nombre, string descripcion, decimal precio, decimal costo, bool disponibilidad)
        {
            /*
             * Esta linea de codigo es la que permitira obtener el id del producto para solo buscar esa id y eliminarlo
                            int id = (int)((Button)sender).CommandParameter;
               OJO el ID esta como string pero existe otra ID de int32 ehacer la prueba con esa 
             */
            using (Model.puntoDeVentaDB_testEntities editar = new Model.puntoDeVentaDB_testEntities()) 
            {
                var ProductoEdit = editar.productos.Find(ID);
                ProductoEdit.nombreProd = nombre;
                ProductoEdit.descripcionProd = descripcion;
                ProductoEdit.precioProd = precio;
                ProductoEdit.costoProd = costo;
                ProductoEdit.disponibilidadProd = disponibilidad;

                editar.Entry(ProductoEdit).State = System.Data.Entity.EntityState.Modified;
                editar.SaveChanges();
            }
            // es recomendable despues de que el metodo se haya ejecutado en el botton llamar otra vez al metodo Refresh()

        }



        //El agregar y editar faltan las imagenes y la columna categoria 



        public void Eliminar(int id)
        {
            /*
             * Esta linea de codigo es la que permitira obtener el id del producto para solo buscar esa id y eliminarlo
                            int id = (int)((Button)sender).CommandParameter;
               OJO el ID esta como string pero existe otra ID de int32 ehacer la prueba con esa 
             */
            using (Model.puntoDeVentaDB_testEntities eliminar = new Model.puntoDeVentaDB_testEntities())             
            {
                var DeleteProduct = eliminar.productos.Find(id);
                eliminar.productos.Remove(DeleteProduct);
                eliminar.SaveChanges();
            }
            // es recomendable despues de que el metodo se haya ejecutado en el botton llamar otra vez al metodo Refresh()
        }
        
        
       


        //Esto no se si dejarlo aqui o que tenga su clase individual(Antes de que se siga moviendo para que no genere error)
        public class PersonViewModel
        {
            public string IDProduct { get; set; }
            public string NombreProduct { get; set; }
            public string DescripcionProduct { get; set; }
            public decimal PrecioProduct { get; set; }
            public decimal CostoProduct { get; set; }
            public bool DisponibilidadProduct { get; set; }            

        }
       
    }
}
