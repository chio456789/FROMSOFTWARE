﻿using System;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for BorrarCliente.xaml
    /// </summary>
    public partial class BorrarCliente : Window
    {
        public BorrarCliente()
        {
            InitializeComponent();
        }

        private void btEliminarCliente_Click(object sender, RoutedEventArgs e)
        {
            String nitCliente = (string)((Button)sender).CommandParameter;

            using (Model.puntoDeVentaDB_testEntities db = new Model.puntoDeVentaDB_testEntities())
            {
                var oCliente = db.clientes.Find(nitCliente);
                db.clientes.Remove(oCliente);
                db.SaveChanges();
                this.Close();

            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
