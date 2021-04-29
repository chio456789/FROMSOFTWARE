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
using WpfApp1.Model;
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
            listarOrdenesNuevas();
        }

        private void BtnEndOrden_Click(object sender, RoutedEventArgs e)
        {
            //GridEndOrden.Background = new SolidColorBrush(Color.FromRgb(254,192,71));
        }

        private void BtnProsOrden_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public void listarOrdenesNuevas()
        {
            List<string> ls = new List<string>();
            using (var d = new puntoDeVentaDB_testEntities())
            {
                var q = (
                    from sm in d.orden where sm.codOrden == 8
                    let queryable = (from nn in d.ordenProductos where nn.orden.codOrden == 8 select nn.productos.nombreProd)
                    select new
                    {
                        orden = sm.codOrden,
                        ordenes = queryable.ToList()
                    }
                    ).ToList();
               

                listaOrdenesNuevas.ItemsSource = q;

            }

        }

        private void BtnProdAgregar1(object sender, RoutedEventArgs e)
        {
            //?
        }
    }
}
