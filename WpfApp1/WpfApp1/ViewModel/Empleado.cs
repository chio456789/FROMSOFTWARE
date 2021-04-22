using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    public class Empleado
    {
        private string ci;
        private string nombre;
        private string apellidoPaterno;
        private string direccion;
        private string correo;
        private Cargo _cargo;

        public Empleado()
        {
            this.init();
        }

        private void init()
        {
            Ci = ci;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            Direccion = direccion;
            Correo = correo;
            Cargo = new Cargo();
        }

        public Empleado(string ci, string nombre, string apellidoPaterno, string direccion, string correo, Cargo cargo)
        {
            Ci = ci;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            Direccion = direccion;
            Correo = correo;
            Cargo = cargo;
        }

        public Empleado(string ci)
        {
            Ci = ci;
        }

        public string Ci { get => ci; set => ci = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public Cargo Cargo { get => _cargo; set => _cargo = value; }
    }
}
