//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            this.orden = new HashSet<orden>();
        }
    
        public int codUsuario { get; set; }
        public string nombreUs { get; set; }
        public string passwordUs { get; set; }
        public string ciEmpleadoFK { get; set; }
        public Nullable<bool> eliminar { get; set; }
    
        public virtual empleado empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orden> orden { get; set; }
        public virtual usuario usuario1 { get; set; }
        public virtual usuario usuario2 { get; set; }
    }
}
