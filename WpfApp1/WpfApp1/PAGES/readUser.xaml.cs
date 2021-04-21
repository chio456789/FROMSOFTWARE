using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.View_model;
using WpfApp1.Model;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Page1Menu.xaml
    /// </summary>
    public partial class Page2Menu : Page
    {
        public Page2Menu()
        {
            InitializeComponent();

            
               
            MyDataGrid.ItemsSource = PerfilUser.Listar();


        }

        public void refresh()
        {
            MyDataGrid.ItemsSource = PerfilUser.Listar();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            EditarUsuario ventanaEditar = new EditarUsuario();
            ventanaEditar.Show();   
        }

        private void btCrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new puntoDeVentaDB_testEntities())
            {
                var emp = new empleado()
                {
                    nombreEmp = tbNombre.Text,
                    apellidoPtEmp = tbApellido.Text,
                    ciEmpleado = tbCI.Text,
                    direccionEmp = tbDireccion.Text,
                    correoEmp = tbCorreo.Text,
                    codCargoFK = 2
                };
                context.empleado.Add(emp);

                var emp2 = new usuario()
                {
                    nombreUs = tbNomUsuario.Text,
                    passwordUs = tbPassword.Password,
                    ciEmpleadoFK = tbCI.Text
                };
                context.usuario.Add(emp2);

                context.SaveChanges();
            }

            tbNombre.Text = "";
            tbDireccion.Text = "";
            tbCI.Text = "";
            tbApellido.Text = "";
            tbPassword.Password = "";
            tbTelefono.Text = "";
            tbNomUsuario.Text = "";


            refresh();

        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            using (var context = new puntoDeVentaDB_testEntities())
            {

                DataRowView row = (DataRowView)MyDataGrid.SelectedItems[0];
                string jh = row["Nombre"].ToString();




                var std = context.empleado.Find(context.cargoLaboral);

                var sd = context.usuario.First<usuario>();


                context.empleado.Remove(std);
                context.usuario.Remove(sd);
                context.SaveChanges();
            }
        }

        public class Item
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string CI { get; set; }
            public string Direccion { get; set; }
            public string Correo { get; set; }
            public string Cargo { get; set; }

          

        }



    }
}
