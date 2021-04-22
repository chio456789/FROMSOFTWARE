using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    public class Usuarios
    {
        private int codUsuario;
        private string nombreUser;
        private string contrasena;
        private Empleado emp2;

        public Usuarios()
        {
            this.init();
        }

        private void init()
        {
            NombreUser = string.Empty;
            Contrasena = string.Empty;
            Emp2 = new Empleado();
        }

        public Usuarios(int codUsuario, string nombreUser, string contrasena, Empleado emp2)
        {
            CodUsuario = codUsuario;
            NombreUser = nombreUser;
            Contrasena = contrasena;
            Emp2 = emp2;
        }

        public int CodUsuario { get => codUsuario; set => codUsuario = value; }
        public string NombreUser { get => nombreUser; set => nombreUser = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        internal Empleado Emp2 { get => emp2; set => emp2 = value; }
    }
}
