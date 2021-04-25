using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame staticmain;

        public MainWindow()
        {
            InitializeComponent();
            staticmain = MainFrame;
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            DialogResult DR = MessageBox.Show("¿Cerrar la sesión actual?", "Serrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DR == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
                log.Show();
            }
            
            
        }

        private void BtnMainWinMenu_Click(object sender, RoutedEventArgs e)
        {
            BtnMainWinMenu.Background = new SolidColorBrush(Color.FromRgb(88,88,88));
            BtnMainWinOrdenes.Background = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            MainFrame.NavigationService.Navigate(new Uri("/Pages/Menu.xaml" ,UriKind.Relative));
        }

        private void BtnMainWinOrdenes_Click(object sender, RoutedEventArgs e)
        {
            BtnMainWinOrdenes.Background = new SolidColorBrush(Color.FromRgb(88, 88, 88));
            BtnMainWinMenu.Background = new SolidColorBrush(Color.FromRgb(62, 62, 62));
            MainFrame.NavigationService.Navigate(new Uri("/Pages/Ordenes.xaml", UriKind.Relative));
        }
    }
}
