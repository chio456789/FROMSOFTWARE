using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    public class Cliente
    {
        private string nit;
        private string nombre;
        private string apellido;

        public Cliente()
        {
            this.init();
        }
    
    private void init()
        {
            Nit = nit;
            Nombre = nombre;
            Apellido = apellido;

        }

        public Cliente(string nit, string nombre, string apellido)
        {
            Nit = nit;
            Nombre = nombre;
            Apellido = apellido;
        }

        public Cliente(string nit)
        {
            Nit = nit;
        }

        public string Nit { get => nit; set => nit = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }

    }
}
