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

            Refresh();
        }
        private void Refresh() 
        {
            List<PersonViewModel> lst = new List<PersonViewModel>();
            using (Model.puntoDeVentaDB_testEntities pop = new Model.puntoDeVentaDB_testEntities())
            {
                lst = (from d in pop.clientes
                       select new PersonViewModel
                       {
                           ID = d.nitCliente,
                           Nombre = d.nombreCliente,
                           Apellido = d.apellidoCliente
                       }).ToList();
            }
            DG.ItemsSource = lst;
            /// se ve mi comentario
            /// Viva la marihuana
            /// FFFF
        }

        public class PersonViewModel 
        { 
             public string ID { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }

        }
    }

}
