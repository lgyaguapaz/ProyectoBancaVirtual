using System;
using System.Data;
using CapaDAL;
namespace CanaNegocio
{
    public class NPlazoFijo
    {
        #region Obtiene NPlazoFijo
        public static DataTable ObtenerPlazoFijo(string identificacion)
        {

            PlazoFijo plazoFijo = new PlazoFijo();
            return plazoFijo.ObtenerPlazoFijo(identificacion);
            
         
        }
        #endregion

        #region Obtiene Transacciones 
        public static DataTable ObtnerTransacciones(string identificacion,string operacion)
        {
            PlazoFijo plazoFijo = new PlazoFijo();
            return plazoFijo.ObtenerCuotas(operacion, identificacion);
        }
        #endregion

        
    }
}
