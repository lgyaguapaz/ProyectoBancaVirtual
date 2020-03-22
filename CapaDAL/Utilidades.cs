using System;
using System.Data.SqlClient;

namespace CapaDAL
{
    public class Utilidades
    {
        //cadena de conexion
        #region Cadena de Conexion
        public static String conexion = Properties.Settings.Default.cn;
        #endregion

        #region Key Encrypt
        public static String key = Properties.Settings.Default.key;
        #endregion


        #region Encriptacion

        public static string EncriptarHas(string cadena)
        {
            CapaSeguridad.Criptografia.EncriptarHash encriptar = new CapaSeguridad.Criptografia.EncriptarHash();

            return encriptar.EncriptarStringHash(cadena, key,null);
        }

        #endregion
        #region Desencriptar

        public static string DesencriptarHas(string cadena)
        {
            CapaSeguridad.Criptografia.DesencriptarHash desencriptar = new CapaSeguridad.Criptografia.DesencriptarHash();

            return desencriptar.DesencriptarStringHash(cadena, key, null);
        }

        #endregion
        #region Encriptacion

        public string EncriptarHashE(string cadena)
        {
            //CapaSeguridad.Criptografia.EncriptarHash encriptar = new CapaSeguridad.Criptografia.EncriptarHash();

            return DesencriptarHas(cadena);
        }

        #endregion
        #region Desencriptar

        public string DesencriptarHashE(string cadena)
        {
            //CapaSeguridad.Criptografia.DesencriptarHash desencriptar = new CapaSeguridad.Criptografia.DesencriptarHash();

            return DesencriptarHas(cadena);
        }

        #endregion


        #region Backup de la aplicacion
        public static string BackupBasedeDatos(string rutaBackup)
        {
            try
            {
                var conexionSql = new SqlConnection(conexion);
                conexionSql.Open();

                var comando = new SqlCommand("[spbackup]", conexionSql);
                comando.CommandType = System.Data.CommandType.StoredProcedure;


                var parRuta = new SqlParameter();
                parRuta.ParameterName = "@ruta";
                parRuta.DbType = System.Data.DbType.String;
                parRuta.Size = 255;
                parRuta.Value = rutaBackup;

                comando.Parameters.Add(parRuta);

                var respuesta = comando.ExecuteNonQuery() == -1 ? "Ok" : "No se proces el backup:";
                conexionSql.Close();

                return respuesta.ToString();
            }
            catch (Exception ex)
            {

                return $"No se procesó el backup: \n{ex.Message}";
            }

        }
        #endregion


    }
}