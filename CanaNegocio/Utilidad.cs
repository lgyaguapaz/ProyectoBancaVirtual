using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL;
namespace CanaNegocio
{
    public class Utilidad
    {

        public string Encriptar(string data)
        {
            Utilidades e = new Utilidades();

            return e.EncriptarHashE(data);
        }

        public string Desencriptar(string data)
        {
            Utilidades e = new Utilidades();

            return e.DesencriptarHashE(data);
        }

    }
}
