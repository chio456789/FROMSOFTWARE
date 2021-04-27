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
using WpfApp1.ViewModel;
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for EditarCliente.xaml
    /// </summary>
    public partial class EditarCliente : Window
    {

        puntoDeVentaDB_testEntities bd = new puntoDeVentaDB_testEntities();
        clientes cli = new clientes();
        static string clinit;
        public EditarCliente(string nitCliente)
        {
            InitializeComponent();
            clinit = nitCliente;
            cli = bd.clientes.Find(clinit);
            tbCICliente.Text = cli.nitCliente;
            tbNombreCliente.Text = cli.nombreCliente;
            tbApellidoCliente.Text = cli.apellidoCliente;
        }

        private void btActualizarCliente_Click(object sender, RoutedEventArgs e)
        {
            //Cliente_ord use = new Cliente_ord();
            //Cliente gg = new Cliente();
            //gg.Nit = tbCICliente.Text;
            //gg.Nombre = tbNombreCliente.Text;
            //gg.Apellido = tbApellidoCliente.Text;

            clientes us4 = this.bd.clientes.Find(clinit);
            this.bd.clientes.Remove(us4);
            //us4.nitCliente = tbCICliente.Text;
            //us4.nombreCliente = tbNombreCliente.Text;
            //us4.apellidoCliente = tbApellidoCliente.Text;

            var oCliente = new Model.clientes();
            oCliente.nitCliente = tbCICliente.Text;
            oCliente.nombreCliente = tbNombreCliente.Text;
            oCliente.apellidoCliente = tbApellidoCliente.Text;


            bd.clientes.Add(oCliente);
            bd.SaveChanges();

            //this.bd.Entry(us4).State = System.Data.Entity.EntityState.Modified;

            //this.bd.SaveChanges();

            //use.UpdateCliente(gg, clinit);

            this.Close();
            WindowAdministrador.ns.Content = new Page2Menu();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
