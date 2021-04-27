using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Model;
using WpfApp1.ViewModel;
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for EditarUsuario.xaml
    /// </summary>
    public partial class EditarUsuario : Window
    {
      

        puntoDeVentaDB_testEntities bd = new puntoDeVentaDB_testEntities();
        usuario us = new usuario();
        empleado emp = new empleado();

       

        public EditarUsuario(string id)
        {

            InitializeComponent();

            us = bd.usuario.Where(x => x.ciEmpleadoFK == id).First();
            emp = bd.empleado.Find(id);
            tbNombre.Text = emp.nombreEmp;
            tbDireccion.Text = emp.direccionEmp;
            tbCI.Text = emp.ciEmpleado;
            tbApellido.Text = emp.apellidoPtEmp;
            tbCorreo.Text = emp.correoEmp;
            tbPassword.Password = us.passwordUs;
            tbNomUsuario.Text = us.nombreUs;
        }


        
        private void btActualizarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario_emp use = new Usuario_emp();

            Empleado em3 = new Empleado();
            Usuarios ui = new Usuarios();
            em3.Nombre = tbNombre.Text;
            em3.ApellidoPaterno = tbApellido.Text;
            em3.Direccion = tbDireccion.Text;
            em3.Ci = tbCI.Text;
            em3.Correo = tbCorreo.Text;
            ui.NombreUser = tbNomUsuario.Text;
            ui.Contrasena = tbPassword.Password;

            use.UpdateEmpleado(em3);
            use.UpdateUser(ui);

            ///hola cara de bola
            this.Close();
            WindowAdministrador.ns.Content = new Page2Menu();

        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
           

        }
    }
}
