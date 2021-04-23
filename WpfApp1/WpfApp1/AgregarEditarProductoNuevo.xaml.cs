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
using WpfApp1.Model;
using WpfApp1.ViewModel;
using WpfApp1.Pages;

namespace WpfApp1
{  
    public partial class AgregarEditarProductoNuevo : Window
    {
        ProductosAdm Actu = new ProductosAdm();
        puntoDeVentaDB_testEntities Datab = new puntoDeVentaDB_testEntities();
        productos pro = new productos();
        categorias categ = new categorias();
        public AgregarEditarProductoNuevo()
        {
            InitializeComponent();
        }
        public AgregarEditarProductoNuevo(int id)
        {
            InitializeComponent();
            // pro = Datab.productos.Where(x => x.codProducto == id).First();
            //categ = Datab.categorias.Find(id);
            pro = Datab.productos.Find(id);
            textboxNP.Text = pro.nombreProd;
            textboxdescrip.Text = pro.descripcionProd;
            textboxcp.Text = Convert.ToString(pro.costoProd);
            textboxpv.Text = Convert.ToString(pro.precioProd);         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Guardado(object sender, RoutedEventArgs e)
        {

            if (textboxNP.Text==""
                || textboxdescrip.Text=="" 
                || textboxcp.Text==""
                || textboxpv.Text==""
                || textcat.Text=="")
            {
                MessageBox.Show("Llene todos los datos","Alerta",MessageBoxButton.OK,MessageBoxImage.Warning);                
            }else

            if (pro != null)
            {
                using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities())
                {
                    var newproducto1 = new Model.productos();
                    newproducto1.nombreProd = textboxNP.Text;
                    newproducto1.descripcionProd = textboxdescrip.Text;
                    newproducto1.costoProd = Convert.ToDecimal(textboxcp.Text);
                    newproducto1.precioProd = Convert.ToDecimal(textboxpv.Text);
                    contexto.Entry(newproducto1).State = System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                }
            }
            else
            {
                using (Model.puntoDeVentaDB_testEntities contexto = new Model.puntoDeVentaDB_testEntities())
                                 {
                                var newproducto = new Model.productos();
                                newproducto.nombreProd = textboxNP.Text;
                                newproducto.descripcionProd = textboxdescrip.Text;
                                newproducto.costoProd = Convert.ToDecimal(textboxcp.Text);
                                newproducto.precioProd = Convert.ToDecimal(textboxpv.Text);            
                                contexto.productos.Add(newproducto);
                                contexto.SaveChanges();                                
                }                           
            }
            this.Close();
        }
        //Act.actualizar();
    }
}
