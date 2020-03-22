using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDAL
{
    public class Cuentas
    {
        //#region Contructores
        //public Cuentas() { }
        //public Cuentas(string key, string cuenta, string oficial, DateTime fechacreacion, string tipoCuenta,
        //                double disponible, double saldo, double saldoMinimo, string estado, string cliente, string TextoBuscar)
        //{
        //    this.key = key;
        //    this.cuenta = cuenta;
        //    this.fechacreacion = fechacreacion;
        //    this.tipoCuenta = tipoCuenta;
        //    this.disponible = disponible;
        //    this.saldo = saldo;
        //    this.saldoMinimo = saldoMinimo;
        //    this.estado = estado;
        //    this.cliente = cliente;
        //    this.TextoBuscar = TextoBuscar;
        //}
        //#endregion

        //#region
        //public string key { get; set; }
        //public string cuenta { get; set; }
        //public string oficial { get; set; }
        //public DateTime fechacreacion { get; set; }
        //public string tipoCuenta { get; set; }
        //public double disponible{ get; set; }
        //public double saldo { get; set; }
        //public double saldoMinimo { get; set; }
        //public string estado { get; set; }
        //public string cliente { get; set; }
        //public string TextoBuscar { get; set; }
        //#endregion


        #region ObtnerCunetas
        public DataTable ObtnerCunetas(string identificacion)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("cuentas");
            var conexionSql = new SqlConnection(Utilidades.conexion);
            

            try
            {
                var comandoSql = new SqlCommand("sp_obtener_cuentas", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;
                var parIdentificacion= new SqlParameter("@Identificacion", SqlDbType.VarChar, 50);
                parIdentificacion.Value = identificacion;
                comandoSql.Parameters.Add(parIdentificacion);

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(resultadoTabla);

                DataColumn workCol = resultadoTabla.Columns.Add("key", typeof(string));

                foreach (DataRow row in resultadoTabla.Rows)
                {
                    //need to set value to NewColumn column
                    row["key"] = Utilidades.EncriptarHas(row["cuenta"].ToString());   // or set it to some other value
                }

            }
            catch (Exception)
            {
                resultadoTabla = null;
            }

            return resultadoTabla;


        }
        #endregion

        #region
        public DataTable ObtenerTransaccionesTop(string Cuenta, string Identificacion)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("transacciones");
            var conexionSql = new SqlConnection(Utilidades.conexion);
            try
            {
                var comandoSql = new SqlCommand("sp_obtener_transcciones_top", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;
                var parIdentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar, 50);
                parIdentificacion.Value = Identificacion;
                comandoSql.Parameters.Add(parIdentificacion);
                var parCuenta = new SqlParameter("@Cuenta", SqlDbType.VarChar, 50);
                parCuenta.Value = Cuenta;
                comandoSql.Parameters.Add(parCuenta);

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(resultadoTabla);

            }
            catch (Exception)
            {
                resultadoTabla = null;
            }

            return resultadoTabla;


        }
        #endregion

        #region
        public DataTable ObtenerTransaccionesFecha(string Cuenta, string Identificacion, DateTime FechaInicio, DateTime FechaFin)
        {
            //Cadena de conexion y DataTable (tabla)
            var resultadoTabla = new DataTable("transacciones");
            var conexionSql = new SqlConnection(Utilidades.conexion);
            try
            {
                var comandoSql = new SqlCommand("sp_obtener_transcciones_fecha", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;
                var parIdentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar, 50);
                parIdentificacion.Value = Identificacion;
                comandoSql.Parameters.Add(parIdentificacion);
                var parCuenta = new SqlParameter("@Cuenta", SqlDbType.VarChar, 50);
                parCuenta.Value = Cuenta;
                comandoSql.Parameters.Add(parCuenta);
                var parFechaInicio = new SqlParameter("@fechaInicio", SqlDbType.DateTime);
                parFechaInicio.Value = FechaInicio;
                comandoSql.Parameters.Add(parFechaInicio);
                var parFechaFin= new SqlParameter("@fechaFin", SqlDbType.DateTime);
                parFechaFin.Value = FechaFin;
                comandoSql.Parameters.Add(parFechaFin);

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(resultadoTabla);

            }
            catch (Exception)
            {
                resultadoTabla = null;
            }

            return resultadoTabla;


        }
        #endregion
    }


}
