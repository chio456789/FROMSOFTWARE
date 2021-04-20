using System;
using System.Collections.Generic;
using System.Collections;
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
using WpfApp1.View_model;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Page1Menu.xaml
    /// </summary>
    public partial class Page2Menu : Page
    {
        public Page2Menu()
        {
            InitializeComponent();

         
            MyDataGrid.ItemsSource = PerfilUser.Listar();


        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                puntoDeVentaDB_testEntities db2 = new puntoDeVentaDB_testEntities();
                
                empleado employer = MyDataGrid.SelectedItem as empleado;
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return;
            }
        }
    }
}
