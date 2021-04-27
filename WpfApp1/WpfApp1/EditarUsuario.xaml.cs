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

        private Usuario_emp dd = new Usuario_emp();
        puntoDeVentaDB_testEntities bd = new puntoDeVentaDB_testEntities();
        usuario us = new usuario();
        empleado emp = new empleado();
        static string us_id;

       

        public EditarUsuario(string id)
        {
            us_id = id;
            InitializeComponent();
            tbCargo.ItemsSource = dd.listar_cargos();


            us = bd.usuario.Where(x => x.ciEmpleadoFK == id).First();
            emp = bd.empleado.Find(id);
            tbNombre.Text = emp.nombreEmp;
            tbDireccion.Text = emp.direccionEmp;
            tbCI.Text = emp.ciEmpleado;
            tbCargo.SelectedValue =emp.cargoLaboral.codCargo;
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
            em3.Cargo = new Cargo((int)tbCargo.SelectedValue);
            ui.NombreUser = tbNomUsuario.Text;
            ui.Contrasena = tbPassword.Password;
            empleado emp4 = this.bd.empleado.Find(us_id);


            emp4.nombreEmp = tbNombre.Text;
            emp4.apellidoPtEmp = tbApellido.Text;
            emp4.direccionEmp = tbDireccion.Text;
            emp4.ciEmpleado = tbCI.Text;
            emp4.correoEmp = tbCorreo.Text;
            emp4.cargoLaboral.codCargo = ((int)tbCargo.SelectedValue);
           
            //emp4.Contrasena = tbPassword.Password;

            use.UpdateEmpleado(em3,us_id);
            //use.UpdateUser(ui);

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
