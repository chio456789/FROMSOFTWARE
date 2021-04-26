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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Lógica de interacción para Ordenes.xaml
    /// </summary>
    public partial class Ordenes : Page
    {
        public Ordenes()
        {
            InitializeComponent();
        }

        private void BtnEndOrden_Click(object sender, RoutedEventArgs e)
        {
            GridEndOrden.Background = new SolidColorBrush(Color.FromRgb(254,192,71));
        }

        private void BtnProsOrden_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
