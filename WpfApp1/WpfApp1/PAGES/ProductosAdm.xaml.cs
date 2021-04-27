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
            actualizarPromocion();
            //this.dataGrid.SearchHelper.Search(TextBox.Text);            
        }       
        private void actualizar()
        {
            List<ProductViewModel> lista = new List<ProductViewModel>();
            using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities())
            {
                lista = (from d in contexto.productos
                         select new ProductViewModel
                         {
                             IdProducto = d.codProducto,
                             NombreProducto = d.nombreProd,
                             DescripcionProducto = d.descripcionProd,
                             PrecioProducto = (decimal)d.precioProd,
                             CostoProducto = (decimal)d.costoProd,
                             DisponibilidadProducto = (bool)d.disponibilidadProd
                         }).ToList();
            }
            DGProductoAdmi.ItemsSource = lista;
        }
        private void actualizarPromocion()
        {
            List<PromoViewModel> lista = new List<PromoViewModel>();
            using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities())
            {
                lista = (from d in contexto.promocion
                         select new PromoViewModel
                         {
                             idPromo = d.codPromocion,
                             NombrePromo = d.nomProm,
                            // EstadoPromo = Convert.ToBoolean(d.estadoProm),
                             DescripcionPromo = d.detalleProm,
                            // precioPromo = (decimal)d.precioProm
                             
                         }).ToList();
            }
            DGPromocion.ItemsSource = lista;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
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
        public class PromoViewModel
        {
            public int idPromo { get; set; }
            public string NombrePromo { get; set; }
            public bool EstadoPromo { get; set; }
            public string DescripcionPromo { get; set; }
          //  public decimal precioPromo { get; set; }
        }



        public class ProductViewModel
            {
            public int IdProducto { get; set; }
            public string NombreProducto { get; set; }
            public string DescripcionProducto { get; set; }
            public decimal PrecioProducto { get; set; }
            public decimal CostoProducto { get; set; }
            public bool DisponibilidadProducto { get; set; }
          //public int Categoria { get; set;}
        }
        private void BotonEditar(object sender, RoutedEventArgs e)
        {
            int tol = (int)((Button)sender).CommandParameter;
            EditarProducto Editarproduct = new EditarProducto(tol);                       
            Editarproduct.Show();
            actualizar();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;

            using (Model.puntoDeVentaDB_testEntities contexto1 = new Model.puntoDeVentaDB_testEntities())
            {
                var promocion = contexto1.promocion.Find(id);
                contexto1.promocion.Remove(promocion);                               
                contexto1.SaveChanges();
            }
            actualizarPromocion();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            
            using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities())
            {
                var newpromo = new Model.promocion();
                newpromo.nomProm = textpromo.Text;
                //newproducto.nombreProd = textboxNP.Text;
                //newproducto.descripcionProd = textboxdescrip.Text;
                //newproducto.costoProd = Convert.ToDecimal(textboxcp.Text);
                //newproducto.precioProd = Convert.ToDecimal(textboxpv.Text);
                //newproducto.disponibilidadProd = Convert.ToBoolean(textdispo.Text);
                contexto.promocion.Add(newpromo);
                contexto.SaveChanges();
            }
        }
    }
}
