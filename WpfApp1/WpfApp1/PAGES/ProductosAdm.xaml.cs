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


namespace WpfApp1.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductosAdm.xaml
    /// </summary>
    public partial class ProductosAdm : Page
    {
        public ProductosAdm()
        {
            InitializeComponent();
            actualizar();
        }
        private void actualizar()
        {
            List<ProductViewModel> lista = new List<ProductViewModel>();
            using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities())
            {
                lista = (from d in contexto.productos
                         select new ProductViewModel
                         {
                             IdProducto = d.idProducto,
                             NombreProducto = d.nombreProd,
                             DescripcionProducto = d.descripcionProd,
                             PrecioProducto = (decimal)d.precioProd,
                             CostoProducto = (decimal)d.costoProd,
                             //DisponibilidadProducto = (bool)d.disponibilidadProd
                         }).ToList();
            }
            DGProductoAdmi.ItemsSource = lista;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // int id = (int)((Button)sender).CommandParameter;

            AgregarEditarProductoNuevo ventanaProducto = new AgregarEditarProductoNuevo();
           
            ventanaProducto.Show();
        }      
        private void BotonEliminar(object sender, RoutedEventArgs e)
        {
            int id =(int)((Button)sender).CommandParameter;

            using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities())
            {
                var produto = contexto.productos.Find(id);
                contexto.productos.Remove(produto);
                contexto.SaveChanges();
            }
            actualizar();
        }
        public class ProductViewModel
            {
            public string IdProducto { get; set; }
            public string NombreProducto { get; set; }
            public string DescripcionProducto { get; set; }
            public decimal PrecioProducto { get; set; }
            public decimal CostoProducto { get; set; }
            //public bool DisponibilidadProducto { get; set; }
           // public int Categoria { get; set; }
        }
        private void BotonEditar(object sender, RoutedEventArgs e)
        {
            int tol = (int)((Button)sender).CommandParameter;
            AgregarEditarProductoNuevo Editarproduct = new AgregarEditarProductoNuevo(tol);           
            Editarproduct.Show();
            actualizar();
        }
    }
}
