//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ordenProductos
    {
        public int idOrdenProductos { get; set; }
        public Nullable<int> codOrdenFK { get; set; }
        public Nullable<int> codProductoFK { get; set; }
        public Nullable<int> cantidad { get; set; }
    
        public virtual orden orden { get; set; }
        public virtual productos productos { get; set; }
    }
}
