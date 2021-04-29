using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;


namespace WpfApp1.ViewModel
{
    class Cliente_ord
    {
        puntoDeVentaDB_testEntities bd = new puntoDeVentaDB_testEntities();
        public bool DeleteClient(string d)
        {
            try
            {
                clientes us3 = this.bd.clientes.Where(s => s.nitCliente == d).FirstOrDefault<clientes>(); ;

                this.bd.clientes.Remove(us3);
                this.bd.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdateCliente(Cliente us3, string yu)
        {
            
            try
            {

                clientes us4 = this.bd.clientes.Find(yu);
                us4.nitCliente = us3.Nit;
                us4.nombreCliente = us3.Nombre;
                us4.apellidoCliente = us3.Apellido;

                this.bd.Entry(us4).State = System.Data.Entity.EntityState.Modified;
                this.bd.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


    }
}
