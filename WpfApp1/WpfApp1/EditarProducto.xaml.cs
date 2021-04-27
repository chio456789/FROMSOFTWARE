using Microsoft.Win32;
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
using System.Windows.Shapes;
using WpfApp1.Model;
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para EditarProducto.xaml
    /// </summary>
    public partial class EditarProducto : Window
    {
        ProductosAdm Actu = new ProductosAdm();
        puntoDeVentaDB_testEntities Datab = new puntoDeVentaDB_testEntities();
        productos pro = new productos();
        categorias categ = new categorias();
        int id = 0;
        public EditarProducto(int PID)
        {
            InitializeComponent();
            this.id = PID;
            InitializeComponent();
            //    // pro = Datab.productos.Where(x => x.codProducto == id).First();
            //    //categ = Datab.categorias.Find(id);
               pro = Datab.productos.Find(id);
               textboxNP.Text = pro.nombreProd;
               textboxdescrip.Text = pro.descripcionProd;
               textboxcp.Text = Convert.ToString(pro.costoProd);
               textboxpv.Text = Convert.ToString(pro.precioProd);   
        }

        private void Editado(object sender, RoutedEventArgs e)
        {
            if (this.id !=0)
            {
                using (Model.puntoDeVentaDB_testEntities contexto1 = new Model.puntoDeVentaDB_testEntities())
                            {
                    var newproducto1 = contexto1.productos.Find(this.id);
                                newproducto1.nombreProd = textboxNP.Text;
                                newproducto1.descripcionProd = textboxdescrip.Text;
                                newproducto1.costoProd = Convert.ToDecimal(textboxcp.Text);
                                newproducto1.precioProd = Convert.ToDecimal(textboxpv.Text);
                          // context.ObjectStateManager.ChangeObjectState(product, EntityState.Modified);
                                contexto1.Entry(newproducto1).State = System.Data.Entity.EntityState.Modified;
                                contexto1.SaveChanges();
                    
                }
            
            }            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnImgEditProd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                ImgProducto.Source = new BitmapImage(fileUri);
                string path = ((BitmapImage)ImgProducto.Source).UriSource.AbsolutePath;
                textboxNP.Text = path;
            }
        }
    }
}
