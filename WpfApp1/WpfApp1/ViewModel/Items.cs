using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.View_model
{
    class Items
    {       
        /// <summary>
        /// Esta permite la conexion de la base de datos y tomaro todo de la lista OJO no pude acceder
        /// a la clase de la base de datos ya que el archivo es un modelo tuve que crear una clase similar al 
        /// de la base de datos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model.productos> Visualizar() 
        {
            using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities()){
                return (IEnumerable<Model.productos>)contexto.productos.AsNoTracking().ToList();
            }        
        }

        public Model.productos Consultar(int id) {
            using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities()) {
                return contexto.productos.FirstOrDefault(p => p.codProducto == id);
            }
        }
        // Este Es el antiguo metodo que usaba para actualizar la vista
        /*
        public List<PersonViewModel> Refresh()
        {
            List<PersonViewModel> lst = new List<PersonViewModel>();
            using (Model.puntoDeVentaDB_testEntities product = new Model.puntoDeVentaDB_testEntities())
            {
                product.categorias  = new categorias();
               lst = (from d in product.productos
                       select new PersonViewModel
                       {
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
        */
        /// <summary>
        /// Guarda un producto en la base de datos
        /// </summary>
        /// <param name="modelo"></param>
        public void Agregarpro(Model.productos modelo) 
        {
            using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities())
            {
                contexto.productos.Add(modelo);
                contexto.SaveChanges();
            }
       
        }
        //Codigo Antigo del agregar
        /* public void agregar(string nombre,string descripcion,decimal precio,decimal costo,bool disponibilidad)
         {           
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
         }*/
        /// <summary>
        /// Edita verificando el ID del producto Falta hacer algunas pruebas
        /// </summary>
        /// <param name="edicion"></param>
        /// <param name="id"></param>
        public void editarprdo(Model.productos edicion,int id=0) 
        {
            if (Convert.ToInt32(Consultar(id))==id)
            {
                using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities())
                            {
                                contexto.Entry(edicion).State = System.Data.Entity.EntityState.Modified;
                                contexto.SaveChanges();
                }
            }            
        }

        /*public void Editar(int ID, string nombre, string descripcion, decimal precio, decimal costo, bool disponibilidad)
        {            
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
        }      
        */
        /// <summary>
        /// El nuevo eliminar con Entity
        /// </summary>
        /// <param name="eliminar"></param>
        /// <param name="id"></param>
        public void eliminarpro(Model.productos eliminar, int id = 0) {

            if (Convert.ToInt32(Consultar(id)) == id)
            {
                using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities()) {
                                contexto.Entry(eliminar).State = System.Data.Entity.EntityState.Deleted;
                                contexto.SaveChanges();               
                 }
            }
            
        }
        // ESTE ES EL ANTIGUO DELETE 
        /*
        public void Eliminar(int id)
        {           
            using (Model.puntoDeVentaDB_testEntities eliminar = new Model.puntoDeVentaDB_testEntities())             
            {
                var DeleteProduct = eliminar.productos.Find(id);
                eliminar.productos.Remove(DeleteProduct);
                eliminar.SaveChanges();
            }   
        }  
        */
    }

    internal class categorias : DbSet<Model.categorias>
    {
    }
}
