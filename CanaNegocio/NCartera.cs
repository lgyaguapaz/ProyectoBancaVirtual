using System;
using System.Data;
using CapaDAL;
namespace CanaNegocio
{
    public class NCartera
    {
        #region Obtiene Creditos
        public static DataTable ObtenerCreditos(string identificacion)
        {
            Cartera cartera = new Cartera();
            return cartera.ObtenerCreditos(identificacion);
        }
        #endregion

        #region Obtiene Transacciones 
        public static DataTable ObtnerTransacciones(string identificacion,string operacion)
        {
            Cartera cartera = new Cartera();
            return cartera.ObtenerCuotas(operacion, identificacion);
        }
        #endregion

        
    }
}
