﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class puntoDeVentaDB_testEntities : DbContext
    {
        public puntoDeVentaDB_testEntities()
            : base("name=puntoDeVentaDB_testEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ordenProductos> ordenProductos { get; set; }
        public virtual DbSet<ordenPromocion> ordenPromocion { get; set; }
        public virtual DbSet<promocionesProductos> promocionesProductos { get; set; }
        public virtual DbSet<cargoLaboral> cargoLaboral { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<factura> factura { get; set; }
        public virtual DbSet<orden> orden { get; set; }
        public virtual DbSet<categorias> categorias { get; set; }
        public virtual DbSet<productos> productos { get; set; }
        public virtual DbSet<promocion> promocion { get; set; }
    }
}
