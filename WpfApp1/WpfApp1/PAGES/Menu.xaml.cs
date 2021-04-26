using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.View_model;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Page1Menu.xaml
    /// </summary>
    public partial class Page1Menu : Page
    {
        WrapPanel sta = new WrapPanel();

        private ObservableCollection<OrdenVm> listaOr = new ObservableCollection<OrdenVm>();

        public Page1Menu()
        {           
            InitializeComponent();
            refresh();
            GetProductos();
            
        }

        private void GetProductos()
        {
            List<Items> ls = new List<Items>();
            using (puntoDeVentaDB_testEntities d = new puntoDeVentaDB_testEntities())
            {
                ls = (
                    from dm in d.productos select new Items
                    {
                        Nombre= dm.nombreProd,
                        Descripcion = dm.descripcionProd,
                        Precio = dm.precioProd,
                        CodProd = dm.codProducto
                       
                    }
                    ).ToList();
                ListaMenu.ItemsSource = ls;

            }

            
        }

        public void Calcular()
        {
           
        }

        private  void BtnProdAgregar1(object sender, RoutedEventArgs e)
        {
            using (puntoDeVentaDB_testEntities d = new puntoDeVentaDB_testEntities())
            {
                object id = (object)((Button)sender).CommandParameter;


                productos prueba = new productos();


                prueba = d.productos.Find(Int32.Parse(id.ToString()));


                int nn = Int32.Parse(rusia.Text);
                decimal? mm = prueba.precioProd;
                string yy = prueba.descripcionProd;


                listaOr.Add(new OrdenVm(nn, mm, yy));

            }
                

          

             refreshorden();

           
            //listaOr.Add(new OrdenVm();
        }

        private void refreshorden()
        {
            DGFactura.ItemsSource = listaOr;
           
            
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
           // DGMenu.ItemsSource = lista;
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
