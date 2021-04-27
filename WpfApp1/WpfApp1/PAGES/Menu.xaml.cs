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

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Page1Menu.xaml
    /// </summary>
    public partial class Page1Menu : Page
    {

        puntoDeVentaDB_testEntities bd = new puntoDeVentaDB_testEntities();
        clientes cli = new clientes();
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
            
            using (Model.puntoDeVentaDB_testEntities db = new Model.puntoDeVentaDB_testEntities())
            {
                var oCliente = new Model.clientes();
                oCliente.nitCliente = txtnitCliente.Text;
                oCliente.nombreCliente = txtnombreCliente.Text;
                oCliente.apellidoCliente = txtapellidoCliente.Text;


                db.clientes.Add(oCliente);
                db.SaveChanges();
                txtnitCliente.Clear();
                txtnombreCliente.Clear();
                txtapellidoCliente.Clear();
            }
            //ConfirmarOrden terminarO = new ConfirmarOrden();
            //terminarO.ShowDialog();

        }

        private void BtnSeleccionarOrden_Click(object sender, RoutedEventArgs e)
        {
            cli = bd.clientes.Find(txtnitCliente.Text);
            txtnitCliente.Text = cli.nitCliente;
            txtnombreCliente.Text = cli.nombreCliente;
            txtapellidoCliente.Text = cli.apellidoCliente;
        }
    }

}
