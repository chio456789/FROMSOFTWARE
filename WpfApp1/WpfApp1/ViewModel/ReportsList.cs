using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class ReportsList
    {
        public static IList listarProductos()
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.CP_reporteProductoDB();
 
                return query.ToList();
            }
        }
        
        public static IList listarVentas()
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.cp_ReporteVentasDB();

                return query.ToList();
            }
        }

        public static IList rangoFechasProducto(DateTime? fecha_1, DateTime? fecha_2)
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.CP_reporteProductosFecha(fecha_1, fecha_2);

                return query.ToList();
            }
        }
        
        public static IList rangoFechasVentas(DateTime? fecha_1, DateTime? fecha_2)
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.CP_reporteEnRangoDB(fecha_1, fecha_2);

                return query.ToList();
            }
        }

        public static IList rangoFechasVentasMes(DateTime? fechaMes)
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.CP_fechaParaMesDB(fechaMes);
                return query.ToList();
            }
        }

        public static IList rangoFechasVentasDia(DateTime? fechaDia)
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.CP_fechaParaDiaDB(fechaDia);
                return query.ToList();
            }
        }

        public static IList rangoFechasVentasSemana(DateTime? fechaDia)
        {
            using (puntoDeVentaDB_testEntities db = new puntoDeVentaDB_testEntities())
            {
                var query = db.CP_fechaParaSemanaDB(fechaDia);
                return query.ToList();
            }
        }

        public static DateTime AltFecha(String f)
        {
            DateTime dt_1 = Convert.ToDateTime(f);

            DateTime fecha = new DateTime(dt_1.Year, dt_1.Month, dt_1.Day, 0, 0, 0);

            return fecha;
        }
    }
}
