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
    /// Interaction logic for Reportes.xaml
    /// </summary>
    public partial class Reportes : Page
    {
        public Reportes()
        {
            InitializeComponent();
            this.refreshReportes();
        }

        public void refreshReportes()
        {
            MyDataGridReportProduc.ItemsSource = ReportsList.listarProductos();
            MyDataGridVentas.ItemsSource = ReportsList.listarVentas();

        }

        private void btImprimir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCrearReporte_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btImprimirDia_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCrearReporteDia_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btImprimirSemana_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCrearReporteSemana_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btImprimirMes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCrearReporteMes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btImprimirRango_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCrearReporteRango_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btGenerarReporte_Click(object sender, RoutedEventArgs e)
        {
           /*switch (cbTipoReporte.Text)
            {
                case "Mas vendido":
                    //MyDataGridReportProduc.ItemsSource = ReportsList.masVendido();
                    break;
                case "Menos vendido":
                    //MyDataGridReportProduc.ItemsSource = ReportsList.menosVendido();
                    break; 
                case "Mayor diferencia":
                   //MyDataGridReportProduc.ItemsSource = ReportsList.mayorDiferencia();
                    break;
                case "Menor diferencia":
                   // MyDataGridReportProduc.ItemsSource = ReportsList.menorDiferencia();
                    break;
                case "Lista":
                    MyDataGridReportProduc.ItemsSource = ReportsList.listarProductos();
                    break;
            }*/
        }
    }
}
