using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;
using System.IO;


namespace  CapaSeguridad.Log
{
    public class CSLog
{


        public static void Log(string logMessage, string cliente, string monto, string opcion, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  Cliente:{0}", cliente);
            w.WriteLine("  Monto:{0}", monto);
            w.WriteLine("  Opcion:{0}", opcion);
            w.WriteLine("  Mensaje:{0}", logMessage);
            w.WriteLine("--------------------------------------------------------------");
        }

        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }


        public string dateToString()
        {
            string format = "yyyyMMdd";
            return DateTime.Now.ToString(format);
        }

        public void write(string logMessage, string cliente, string monto, string opcion)
        {

            string path = "C:\\logs\\" + dateToString() + ".txt";

            using (StreamWriter w = File.AppendText(path))
            {
                Log(logMessage, cliente, monto, opcion, w);

            }

            using (StreamReader r = File.OpenText(path))
            {
                DumpLog(r);
            }
        }



    }
}
