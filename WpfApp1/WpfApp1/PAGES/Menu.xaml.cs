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

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Page1Menu.xaml
    /// </summary>
    public partial class Page1Menu : Page
    {
        public Page1Menu()
        {           
            InitializeComponent();
            refresh();           
        }
        private void refresh()
        {
            List<ProductViewModel> lista = new List<ProductViewModel>();
            //DGMenu.ItemsSource = lista;
            using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities())
            {
                lista = (from d in contexto.productos
                         select new ProductViewModel
                         {
                             IdProducto = d.idProducto,
                             NombreProducto = d.nombreProd,
                             DescripcionProducto = d.descripcionProd,
                             PrecioProducto = (decimal)d.precioProd,
                            // DisponibilidadProducto = (bool)d.disponibilidadProd
                         }).ToList();    
            }
            //DGMenu.ItemsSource = lista;
        }
            public class ProductViewModel
        {
            public string IdProducto { get; set; }
            public string NombreProducto { get; set; }
            public string DescripcionProducto { get; set; }
            public decimal PrecioProducto { get; set; }
         //   public bool DisponibilidadProducto { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnTerminarOrden_Click(object sender, RoutedEventArgs e)
        {
            ConfirmarOrden terminarO = new ConfirmarOrden();
            terminarO.ShowDialog();
        }
    }

}
