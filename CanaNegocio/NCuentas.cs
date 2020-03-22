using System;
using System.Data;
using CapaDAL;
namespace CanaNegocio
{
    public class NCuentas
    {
        #region Obtiene Cuentas
        public static DataTable ObtenerCuentas(string identificacion)
        {
            DataTable dataTable = new DataTable();
            Cuentas cuentas = new Cuentas();
            return cuentas.ObtnerCunetas(identificacion);
            
         
        }
        #endregion

        #region Obtiene Transacciones Top
        public static DataTable ObtnerTransaccionesTop(string identificacion,string cuenta)
        {
            Cuentas cuentas = new Cuentas();
            return cuentas.ObtenerTransaccionesTop(cuenta, identificacion);
        }
        #endregion

        #region Obtiene Transacciones Fecha
        public static DataTable ObtnerTransaccionesFecha(string identificacion, string cuenta, DateTime FechaInicio, DateTime FechaFin)
        {
            Cuentas cuentas = new Cuentas();
            return cuentas.ObtenerTransaccionesFecha(cuenta, identificacion, FechaInicio, FechaFin);
        }
        #endregion
    }
}
