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

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainVentana = new MainWindow();
            WindowAdministrador adminW = new WindowAdministrador();

            puntoDeVentaDB_testEntities bd = new puntoDeVentaDB_testEntities();

            var q = from d in bd.usuario
                    where d.nombreUs == TbNombreUsuarioLogin.Text &&
d.passwordUs == PasswordBoxLogin.Password && d.empleado.cargoLaboral.nombreCg == "Administrador"
                    select d;
            var m = from s in bd.usuario
                    where s.nombreUs == TbNombreUsuarioLogin.Text &&
s.passwordUs == PasswordBoxLogin.Password && s.empleado.cargoLaboral.nombreCg == "Cajero"
                    select s;


            if (m.Count()>0)
            {
                MessageBox.Show("Bienvenido "+ TbNombreUsuarioLogin.Text);
                mainVentana.Show();
                this.Close();
            }
            else if (q.Count()>0)
            {
                MessageBox.Show("Bienvenido " + TbNombreUsuarioLogin.Text);
                adminW.Show();
                this.Close();
            }else
            {
                TblDatosIncorrectos.Text = "Usuario o contraseña incorrectos" ;
                TbNombreUsuarioLogin.Text = "";
                PasswordBoxLogin.Password = "";
            }

        }

        private void BtnSalirLogin_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
