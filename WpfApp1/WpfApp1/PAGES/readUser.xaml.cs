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
            try
            {
                
                puntoDeVentaDB_testEntities db2 = new puntoDeVentaDB_testEntities();

                empleado employer = (empleado)MyDataGrid.SelectedItem;

                string mm = employer.ciEmpleado;
                empleado p = db2.empleado.Find(mm);

                tbNombre.Text = p.nombreEmp;

            }


            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            using (var context = new puntoDeVentaDB_testEntities())
            {
                //var std = context.Students.First<Student>();
                //context.Students.Remove(std);

                //context.SaveChanges();
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new puntoDeVentaDB_testEntities())
            {
                var emp = new empleado()
                {
                    nombreEmp = tbNombre.Text,
                    apellidoPtEmp = tbApellido.Text,
                    ciEmpleado = tbCI.Text,
                    direccionEmp= tbDireccion.Text,
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
    }
}
