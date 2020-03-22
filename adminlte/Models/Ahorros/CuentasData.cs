using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CanaNegocio;

namespace adminlte.Models.Ahorros
{
    public class CuentasData
    {
                      
        public List<DropdownCuentasModel> CuentasList(string user)
        {
            NCuentas cuentas = new NCuentas();

            DataTable reportDetailsTable = NCuentas.ObtenerCuentas(user);

            List<DropdownCuentasModel> objCuentas = new List<DropdownCuentasModel>();
            int s = reportDetailsTable.Rows.Count;
            for (int i = 0; i < s; i++)
            {
                string d1 = reportDetailsTable.Rows[i]["cuenta"].ToString();
                string d2 = reportDetailsTable.Rows[i]["cuenta"].ToString();
                objCuentas.Add(new DropdownCuentasModel { ID = d1, Name = d2 });
            }
            return objCuentas;

        }

            public ExistModel getId(string id)
        {
            ExistModel e = new ExistModel();
            ApplicationDbContext context = new ApplicationDbContext();
            
            SqlConnection conn = (SqlConnection)context.Database.Connection;
            conn.Open();
            SqlTransaction transaccionSql = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand("sp_buscarCliente", conn, transaccionSql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Identificacion", id);
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            //cmd.Parameters.Add("@LI_RET", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            try
            {
                //cmd.ExecuteNonQuery();
                int res = Convert.ToInt32(cmd.ExecuteNonQuery());// cmd.ExecuteNonQuery();
                string mensaje = (string)cmd.Parameters["@Mensaje"].Value;
                string Nombre = (string)cmd.Parameters["@Nombre"].Value;
                //int res = int.Parse(cmd.Parameters["@LI_RET"].Value.ToString());


                if (res >0 )
                {
                    transaccionSql.Commit();
                    e.identificacion = id;
                    e.mensaje = mensaje;
                    e.nombre = Nombre;
                    e.ret = res;
                }
                else if(res == -1)
                {
                    transaccionSql.Rollback();
                    e.identificacion = id;
                    e.mensaje = mensaje;
                    e.nombre = Nombre;
                    e.ret = res;
                }
                conn.Close();
                return e;
            }
            catch (Exception ex)
            {

                return e;
            }
            finally
            {

                conn.Close();
                conn.Dispose();
                conn = null;
            }

            
        }
        public List<AccountTranModel> getAccounTransTop(int top)
        {
            List<AccountTranModel> list = new List<AccountTranModel>();
            AccountTranModel e = new AccountTranModel()
            {
                cuenta = "123231",
                fecha = DateTime.Now,
                disponible = 500,
                valor = 520,
                tipo = "Deposito"

            };
            list.Add(e);
            AccountTranModel e1 = new AccountTranModel()
            {
                cuenta = "123231",
                fecha = DateTime.Now,
                disponible = 500,
                valor = 520,
                tipo = "Retiro"

            };
            list.Add(e1);
            return list;
        }

        public List<AccountTranModel> getAccounTransDate(DateTime ini, DateTime end)
        {
            List<AccountTranModel> list = new List<AccountTranModel>();
            AccountTranModel e = new AccountTranModel()
            {
                cuenta = "123231",
                fecha = DateTime.Now,
                disponible = 500,
                valor = 520,
                tipo = "Deposito"

            };
            list.Add(e);
            AccountTranModel e1 = new AccountTranModel()
            {
                cuenta = "123231",
                fecha = DateTime.Now,
                disponible = 500,
                valor = 520,
                tipo = "Retiro"

            };
            list.Add(e1);
            AccountTranModel e2 = new AccountTranModel()
            {
                cuenta = "123231",
                fecha = DateTime.Now,
                disponible = 2,
                valor = 222,
                tipo = "Retiro"

            };
            list.Add(e2);
            return list;
        }
    }
}
