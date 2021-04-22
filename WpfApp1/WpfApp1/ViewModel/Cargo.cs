using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    public class Cargo
    {
        private int codCargo;
        private string nombreCargo;
        private string descripcion;

        
        public Cargo(int codCargo)
        {
            CodCargo = codCargo;
        }

        public Cargo()
        {
            this.init();
        }

        private void init()
        {
            Descripcion = string.Empty;
        }

        public Cargo(string nombreCargo, string descripcion, int codCargo)
        {
            NombreCargo = nombreCargo;
            Descripcion = descripcion;
            CodCargo = codCargo;
        }

        public string NombreCargo { get => nombreCargo; set => nombreCargo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int CodCargo { get => codCargo; set => codCargo = value; }
    }
}
