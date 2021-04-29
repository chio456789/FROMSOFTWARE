using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
            //Dia
            if (LocaleDatePickerDia.Text != "")
            {
                MyDataGridVentas.ItemsSource = ReportsList.rangoFechasVentasDia(ReportsList.AltFecha(LocaleDatePickerDia.Text));
            }
            else
            {
                MessageBox.Show("La fecha del Dia no puede estar vacia");
            }
        }

        private void btImprimirSemana_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCrearReporteSemana_Click(object sender, RoutedEventArgs e)
        {
            //Semana
            if (LocaleDatePickerSemana.Text != "")
            {
                MyDataGridVentas.ItemsSource = ReportsList.rangoFechasVentasSemana(ReportsList.AltFecha(LocaleDatePickerSemana.Text));
            }
            else
            {
                MessageBox.Show("La fecha del Semana no puede estar vacia");
            }
        }

        private void btImprimirMes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCrearReporteMes_Click(object sender, RoutedEventArgs e)
        {
            //Mes
            
            if (LocaleDatePickerMes.Text != "")
            {
                MyDataGridVentas.ItemsSource = ReportsList.rangoFechasVentasMes(ReportsList.AltFecha(LocaleDatePickerMes.Text));
            }
            else
            {
                MessageBox.Show("La fecha del mes no puede estar vacia");
            }
        }

        private void btImprimirRango_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btCrearReporteRango_Click(object sender, RoutedEventArgs e)
        {
            

            //MessageBox.Show(DateTime.Now.ToString("yyyy-dd-MM")); 

            
                if (LocaleDatePickerRangoDe.Text != "" && LocaleDatePickerRangoDe.Text != "")
                {
                    DateTime dt_1 = Convert.ToDateTime(LocaleDatePickerRangoDe.Text);
                    DateTime dt_2 = Convert.ToDateTime(LocaleDatePickerRangoHasta.Text);
                    if (dt_1 > dt_2)
                    {
                        MessageBox.Show("La primera fecha tiene que ser menor a la segunda");
                    }
                    else
                    {
                        DateTime fecha_1 = new DateTime(dt_1.Year, dt_1.Month, dt_1.Day, 0, 0, 0);
                        DateTime fecha_2 = new DateTime(dt_2.Year, dt_2.Month, dt_2.Day, 0, 0, 0);

                        MyDataGridVentas.ItemsSource = ReportsList.rangoFechasVentas(fecha_1, fecha_2);
                    }
                
                }
                else
                {
                    MessageBox.Show("Para realizar un reporte la fecha debe tener dos Fechas");
                }
            
        }

        private void btGenerarReporte_Click(object sender, RoutedEventArgs e)
        {
            
            //MessageBox.Show(DateTime.Now.ToString("yyyy-dd-MM")); 

                if (LocaleDatePickerDe.Text != "" && LocaleDatePickerHasta.Text != "")
                {
                    
                    DateTime dt_1 = Convert.ToDateTime(LocaleDatePickerDe.Text);
                    DateTime dt_2 = Convert.ToDateTime(LocaleDatePickerHasta.Text);

                    if (dt_1 > dt_2)
                    {
                        MessageBox.Show("La primera fecha tiene que ser menor a la segunda");
                    }
                    else
                    {
                        DateTime fecha_1 = new DateTime(dt_1.Year, dt_1.Month, dt_1.Day, 0, 0, 0);
                        DateTime fecha_2 = new DateTime(dt_2.Year, dt_2.Month, dt_2.Day, 0, 0, 0);
                        MyDataGridReportProduc.ItemsSource = ReportsList.rangoFechasProducto(fecha_1, fecha_2);
                    }
                }
                else
                {
                    MessageBox.Show("Para realizar un reporte las fechas debe tener datos.");
                }
            
        }

        private void btRestaurarProductos_Click(object sender, RoutedEventArgs e)
        {
            MyDataGridReportProduc.ItemsSource = ReportsList.listarProductos();
        }

        private void btRestaurarVentas_Click(object sender, RoutedEventArgs e)
        {
            MyDataGridVentas.ItemsSource = ReportsList.listarVentas();
        }
    }
}
