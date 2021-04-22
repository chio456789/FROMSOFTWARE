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
    /// Lógica de interacción para WindowAdministrador.xaml
    /// </summary>
    public partial class WindowAdministrador : Window
    {
        public WindowAdministrador()
        {
            InitializeComponent();
        }

        private void BtnAdmCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            this.Close();
            log.Show();
        }

        private void BtnAdmProductos_Click(object sender, RoutedEventArgs e)
        {
            BtnAdmProductos.Background = new SolidColorBrush(Color.FromRgb(88, 88, 88));
            BtnAdmCuentas.Background = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            BtnAdmReportes.Background = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            MainAdmFrame.NavigationService.Navigate(new Uri("/Pages/ProductosAdm.xaml", UriKind.Relative));
        }

        private void BtnAdmReportes_Click(object sender, RoutedEventArgs e)
        {
            BtnAdmReportes.Background = new SolidColorBrush(Color.FromRgb(88, 88, 88));
            BtnAdmProductos.Background = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            BtnAdmCuentas.Background = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            MainAdmFrame.NavigationService.Navigate(new Uri("/Pages/Reportes.xaml", UriKind.Relative));
        }

        private void BtnAdmCuentas_Click(object sender, RoutedEventArgs e)
        {
            BtnAdmCuentas.Background = new SolidColorBrush(Color.FromRgb(88, 88, 88));
            BtnAdmProductos.Background = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            BtnAdmReportes.Background = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            MainAdmFrame.NavigationService.Navigate(new Uri("/Pages/readUser.xaml", UriKind.Relative));
        }
    }
}
