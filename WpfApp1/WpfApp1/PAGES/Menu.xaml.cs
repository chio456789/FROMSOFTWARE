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
        public static int hu=0;

        decimal? valor = 0;

        public Page1Menu()
        {           
            InitializeComponent();
            refresh();
            GetProductos();
            actualizarPromocion();
        }

        private void GetProductos()
        {
            List<Items> ln = new List<Items>();
            using (puntoDeVentaDB_testEntities d = new puntoDeVentaDB_testEntities())
            {
               var ls = (
                    from dm in d.productos select new 
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

        private void cantidad_change(object sender, SelectionChangedEventArgs e)
        {

            ComboBoxItem cbi1 = (ComboBoxItem)(sender as ComboBox).SelectedItem;
            object select = cbi1.Content;
            string v = select.ToString();
            hu = Int32.Parse(v) ;


        }
        private  void BtnProdAgregar1(object sender, RoutedEventArgs e)
        {
            OrdenVm ov = new OrdenVm();
            using (puntoDeVentaDB_testEntities d = new puntoDeVentaDB_testEntities())
            {
                object id = (object)((Button)sender).CommandParameter;

                productos prueba = new productos();

                prueba = d.productos.Find(Int32.Parse(id.ToString()));


                //int nn = Int32.Parse(rusia.Text);
                decimal? mm = prueba.precioProd;
                string yy = prueba.descripcionProd;


                listaOr.Add(new OrdenVm(hu, mm, yy,Int32.Parse(id.ToString())));

               
                valor += ov.subtotalItem(hu, mm);
                tbTotal.Text = valor.ToString();
            }

             refreshorden();

        }

        private void refreshorden()
        {
            DGFactura.ItemsSource = listaOr;
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
            DGPromo.ItemsSource = lista;
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
        public class PromoViewModel
        {
            public int idPromo { get; set; }
            public string NombrePromo { get; set; }
            public bool EstadoPromo { get; set; }
            public string DescripcionPromo { get; set; }
            //  public decimal precioPromo { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnTerminarOrden_Click(object sender, RoutedEventArgs e)
        {
            /*ConfirmarOrden terminarO = new ConfirmarOrden();
            terminarO.ShowDialog();*/
            string carnet = tbCarnetCliente.Text;
            puntoDeVentaDB_testEntities nuevo = new puntoDeVentaDB_testEntities();
            clientes nm = new clientes();
            orden kl = new orden();
            ordenProductos jk = new ordenProductos();
            
            var q= nuevo.clientes.Find(carnet);

         //inicio guardar factura ---------------------------------
            TotalFactura tf = new TotalFactura();
            FacturaOrden fo = new FacturaOrden();

            


            tf.TotalFac = Convert.ToDecimal(tbTotal.Text);
            tf.UltimoReg = tf.encontrarUltimaOrden();

            //**********guardar cliente


            

            if (q == null)
            {
                MessageBox.Show("no existe este cliente");
                nm.nitCliente = tbCarnetCliente.Text;
                nm.nombreCliente = tbNombreCliente.Text;
                nm.apellidoCliente = tbApellidoCliente.Text;
                nuevo.clientes.Add(nm);
                nuevo.SaveChanges();
                MessageBox.Show("guardado cliente");
                kl.nitClienteFK = tbCarnetCliente.Text;
                kl.estadoOrden = true;
                nuevo.orden.Add(kl);
                nuevo.SaveChanges();
                MessageBox.Show("orden guardada");
               

                foreach (var mn in listaOr)
                {
                    jk.codOrdenFK = tf.UltimoReg;
                    jk.codProductoFK = mn.cod_Producto;
                    jk.cantidad = mn.cantidad;
                    nuevo.ordenProductos.Add(jk);
                    nuevo.SaveChanges();
                   

                }
                MessageBox.Show("listaguardadda");


            }



            if (fo.guardarFactura(tf))
            {

                MessageBox.Show("Factura Guardada");
                tbTotal.Text = "";
                listaOr.Clear();
                tbCarnetCliente.Text = "";
                tbApellidoCliente.Text = "";
                tbNombreCliente.Text = "";

            }
            else
            {
                MessageBox.Show("Error al guardar la factura");
            }

         //fin guardar factura---------------------------------
        }
    }

}
