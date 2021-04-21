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

            if (TbNombreUsuarioLogin.Text == "1" && PasswordBoxLogin.Password == "1")
            {
                MessageBox.Show("Bienvenido "+ TbNombreUsuarioLogin.Text);
                mainVentana.Show();
                this.Close();
            }
            else
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
